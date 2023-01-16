var countDownDate; // 15 minutes in milliseconds

if (localStorage.getItem("countDownDate")) {
    var current = new Date().getTime();
    var expire = sessionStorage.getItem("expire");
    var retrievedValue = parseInt(localStorage.getItem("countDownDate"));
    countDownDate = !isNaN(retrievedValue) && current > expire? retrievedValue : new Date().getTime() + 900000;
} else {
    var countTime = new Date().getTime() + 900000;
    sessionStorage.setItem("expire", countTime);
    countDownDate = countTime;
}
localStorage.setItem("countDownDate", countDownDate);

var x = setInterval(function () {
    var now = new Date().getTime();
    var distance = countDownDate - now;

    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    document.getElementById("countdown").innerHTML = minutes + ":" + seconds;

    if (distance < 0) {
        clearInterval(x);
        alert("Time's up!");
        resetLocalStorage();
        document.getElementById("quizForm").submit();
    }
}, 1000);

function resetLocalStorage() {
    localStorage.clear();
}