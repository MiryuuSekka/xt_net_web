var Input = document.getElementById("InputData");
var Output = document.getElementById("LabelResult");
var Result;
var formula;

Input.onchange = function () { ChangeText() };

function ChangeText() {
    if (GetFormula(Input.value)) {
        Result = Calculate(formula);
    }
    Output.textContent = Result;
};

function Calculate(formula) {
    Result = null;
    var number = '';
    var move = '';
    var char;
    for (var i = 0; i < formula.length; i++) {
        char = formula[i];

        if (char == '=') {
            Result = CalculateStep(move, Result, number);
            return Result;
        }
        
        if (/[\d.]/.test(char)) {
            number += char;
        }
        
        if (/[-/*+.=]/.test(char)) {
            if (Result != null) {
                Result = CalculateStep(move, Result, number);
            }
            else {
                Result = number;
            }
            move = char;
            number = '';
        }
    };
    return Result;
}


function CalculateStep(Move, Number1, Number2) {
    
    switch (Move) {
        case '+':
            return parseInt(Number1, 10) + parseInt(Number2, 10);
        case '-':
            return parseInt(Number1, 10) - parseInt(Number2, 10);
        case '/':
            return parseInt(Number1, 10) / parseInt(Number2, 10);
        case '*':
            return parseInt(Number1, 10) * parseInt(Number2, 10);

        default:
            return Result;
    }
};

function GetFormula(String) {
    formula = String.replace(/[^-\d/*+.=]/g, '');
    if (!formula.match(/[=]/)) {
        Result = "didnt find \"=\" at formule";
        return false;
    }
    return true;
};