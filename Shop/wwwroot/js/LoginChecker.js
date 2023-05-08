
function sendLoginData(event) {
    event.preventDefault();

    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "../Login/CheckLogin", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                var response = JSON.parse(this.responseText);
                if (response.success) {
                    window.location.href = "../Product/ShowPage";
                }
                else {
                    error(event, response.message);
                }
            } else {
                error(event, "Server error");
            }
        }
    };
    xhr.send("username=" + encodeURIComponent(username) + "&password=" + encodeURIComponent(password));
}

function sendSignInData(event) {
    event.preventDefault();

    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var email = document.getElementById("email").value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "../Login/CheckSignIn", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                var response = JSON.parse(this.responseText);
                if (response.success) {
                    window.location.href = "/Login/Login";
                } else {
                    error(event, response.message);
                }
            } else {
                error(event, "Server error");
            }
        }
    };
    xhr.send("username=" + encodeURIComponent(username) +
        "&password=" + encodeURIComponent(password) +
        "&email=" + encodeURIComponent(email));
}