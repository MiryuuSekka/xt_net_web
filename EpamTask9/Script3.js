var Boxes = document.getElementsByClassName("box");
var buttons = document.getElementsByClassName("Button");
var Error = document.getElementById("Error");
var BaseBox;
var TargetBox;

for (var i = 0; i < buttons.length; i++) {
    buttons[i].onclick = function () { OnClick() };
};


function OnClick() {
    var PanelNumber = GetPanelNumber(event.target.id);
    GetBoxNumber(PanelNumber, event.target.name);
    var Lines = GetLines();
    if (Lines.length > 0 || event.target.name.indexOf("All") > -1){
        MoveLines(event.target.name, Lines);
        Error.innerHTML = "";
    }
    else {
        Error.innerHTML = "Wrong arguments. Select 1 or more line for move them";
    }
    ClearSelection();
}

function GetBoxNumber(PanelNumber, ButtonName) {
    switch (ButtonName) {
        case "ToLeft":
        case "AllToLeft":
            BaseBox = PanelNumber + 1;
            TargetBox = PanelNumber;
            break;

        case "ToRight":
        case "AllToRight":
            TargetBox = PanelNumber + 1;
            BaseBox = PanelNumber;
            break;

        default:
            BaseBox = null;
            TargetBox = null;
            break;
    }
};

function GetPanelNumber(id) {
    return Math.floor(id / 4);
};

function GetLines() {
    var selected = Boxes[BaseBox].selectedOptions;
    return selected;
};

function MoveLines(Type, Lines) {
    switch (Type) {
        case "ToLeft":
        case "ToRight":
            for (var i = Lines.length-1; i > -1; i--) {
                Boxes[TargetBox].add(Lines[i]);
            }
            break;

        case "AllToLeft":
        case "AllToRight":
            Lines = Boxes[BaseBox].children;
            for (var i = Lines.length-1; i > -1 ; i--) {
                Boxes[TargetBox].add(Lines[i]);
            }
            break;

        default:
            break;
    }
};

function ClearSelection() {
    for (var i = 0; i < Boxes.length; i++) {
        Boxes[i].options.selectedIndex = -1;
    }
};
