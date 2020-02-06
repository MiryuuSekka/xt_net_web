var PageNow = 0;
var counter = 30;
var IsPaused = false;

var Time = window.document.getElementById("Timer");

setInterval(function () { RefreshTime() }, 500);

function RefreshTime() {
    if (!IsPaused) {
        Time.textContent = counter.toString();
    }
    else {
        Time.textContent = "Paused";
    }
}