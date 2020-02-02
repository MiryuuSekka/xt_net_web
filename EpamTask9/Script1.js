var Input = document.getElementById("InputData");
var Output = document.getElementById("LabelResult");
var Symbols;

Input.onchange = function () { ChangeText() };

function ChangeText() {
    Symbols = [];
    Output.textContent = GetFullText(Input.value);
};

function GetFullText(InputText) {
    var Words = GetWordsFromText(InputText);

    for (var i = 0; i < Words.length; i++) {
        SearchRepeatsInWord(Words[i]);
    };
    for (var i = 0; i < Symbols.length; i++) {
        InputText = deleteChar(Symbols[i], InputText);
    };
    return InputText;
};

function GetWordsFromText(InputText) {
    InputText = replaceChar('?', InputText);
    InputText = replaceChar('!', InputText);
    InputText = replaceChar(':', InputText);
    InputText = replaceChar(';', InputText);
    InputText = replaceChar(',', InputText);
    InputText = replaceChar('.', InputText);
    return InputText.split(' ');
};

function replaceChar(Char, InputText) {
    var result;
    do {
        result = InputText.indexOf(Char);
        InputText = InputText.replace(Char, " ");
    } while (result != -1);
    return InputText;
};

function deleteChar(Char, InputText) {
    var result;
    do {
        result = InputText.indexOf(Char);
        InputText = InputText.replace(Char, "");
    } while (result != -1);
    return InputText;
};


function CharIsRepeated(InputText, Char) {
    InputText = InputText.replace(Char, " ");
    var result = InputText.indexOf(Char); 
    return result > -1;
};

function SearchRepeatsInWord(Word) {
    for (var i = 0; i < Word.length; i++) {
        if (CharIsRepeated(Word, Word[i])) {
            if (Symbols.indexOf(Word[i]) == -1) {
                Symbols.push(Word[i]);
            };
        };
    };
};


