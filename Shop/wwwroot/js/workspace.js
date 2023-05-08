function saveClientType(type) {

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "../Login/SaveClientType", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                var response = JSON.parse(this.responseText);
                if (response.success) {
                    window.location.href = "../Login/Login";
                } else {
                    error(event, response.message);
                }
            } else {
                error(event, "Server error");
            }
        }
    };
    xhr.send("type=" + encodeURIComponent(type));
}