function error(event, message) {

    event.preventDefault();
    var errorDiv = document.createElement('div');
    errorDiv.className = 'error';
    errorDiv.textContent = message;
    document.body.appendChild(errorDiv);

    errorDiv.classList.add('show');

    setTimeout(function () {

        errorDiv.classList.remove('show');
        setTimeout(function () {
            errorDiv.parentNode.removeChild(errorDiv);
        }, 500);
    }, 5000);
}