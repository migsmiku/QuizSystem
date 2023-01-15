var countDownDate; // 15 minutes in milliseconds

if (localStorage.getItem("countDownDate")) {
    var retrievedValue = parseInt(localStorage.getItem("countDownDate"));
    countDownDate = !isNaN(retrievedValue) ? retrievedValue : new Date().getTime() + 900000;
} else {
    countDownDate = new Date().getTime() + 900000;
}
localStorage.setItem("countDownDate", countDownDate);

var x = setInterval(function () {
    var now = new Date().getTime();
    var distance = countDownDate - now;

    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    document.getElementById("countdown").innerHTML = minutes + "m " + seconds + "s ";

    if (distance < 0) {
        clearInterval(x);
        alert("Time's up!");
        resetTimer();
        //document.getElementById("quizForm").submit();
    }
}, 1000);

function resetTimer() {
    localStorage.removeItem("countDownDate");
}