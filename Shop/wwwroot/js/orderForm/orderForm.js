function placeOrder(event, customer) {

    event.preventDefault();
    const invalidChar = "./,\*-+=)]}&^%$#@!'\"";

    const inputs = document.querySelectorAll('input');
    const data = {};

    for (let i = 0; i < inputs.length; i++) {
        const input = inputs[i];
        data[input.name] = input.value;
    }

    /*Check Firstname*/{
        if (data.firstName.length == 0) {
            error(event, "FirstName contains invalid characters");
            return
        }
        for (let i = 0; i < data.firstName.length; i++) {
            if (invalidChar.includes(data.firstName[i])) {
                error(event, "FirstName contains invalid characters");
                return;
            }
        }
    }
    /*Check Lastname*/{
        if (data.lastName.length == 0) {
            error(event, "LastName contains invalid characters");
            return
        }
        for (let i = 0; i < data.lastName.length; i++) {
            if (invalidChar.includes(data.lastName[i])) {
                error(event, "LastName contains invalid characters");
                return;
            }
        }
    }
    /*Check Email*/{
        if (!data.email.includes("@gmail.com")) {
            error(event, "Invalid email");
            return;
        }
    }
    /*Check Phone*/{
        if (data.phone.length != 10) {
            error(event, "Invalid phone format (Example: 0972553852)");
            return;
        }
        for (let i = 0; i < data.phone.length; i++) {
            if (invalidChar.includes(data.phone[i])) {
                error(event, "Phone contains invalid characters");
                return;
            }
        }
    }

    customer.firstName = data.firstName;
    customer.lastName = data.lastName;
    customer.email = data.email;
    customer.phone = data.phone;
    customer.adress = data.address;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "../Order/PlaceOrder", false);
    xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            window.location.href = "../Order/PlaceOrderForm";
        }
        else {
            error(event, "Error");
        }
    };
    xhr.send(JSON.stringify(customer));
}