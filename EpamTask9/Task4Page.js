var Pages = [
    "Task4page1.html",
    "Task4page2.html",
    "Task4page3.html",
    "Task4page4.html",
    "Task4page5.html",
    "LastPage.html"
];
var childPageNow = window.parent.PageNow;

window.parent.counter = 10;
setInterval(function () { TimerSettings() }, 1000);



function TimerSettings() {
    if (childPageNow === Pages.length - 1) {
        if (!window.parent.IsPaused) {
            PauseTimer();
        }
    }
    if (!window.parent.IsPaused) {
        window.parent.counter--;
        if (window.parent.counter === 0) {
            NextPage();
        }
    }
};

function StartTimer() {
    window.parent.IsPaused = false;
    window.parent.counter = 10;
};

function PauseTimer() {
    if (!window.parent.IsPaused) {
        window.parent.IsPaused = true;
    }
    else {
        window.parent.IsPaused = false;
        StartTimer();
    }
};



function FirstPage() {
    childPageNow = 0;
    OpenPage();
};

function NextPage() {
    if (childPageNow < Pages.length - 1) {
        childPageNow++;
        OpenPage();
    }
};

function BackPage() {
    if (childPageNow > 0) {
        childPageNow--;
        OpenPage();
    }
};

function OpenPage() {
    window.parent.PageNow = childPageNow;
    window.open(Pages[childPageNow], '_self', false);
};


StartTimer();