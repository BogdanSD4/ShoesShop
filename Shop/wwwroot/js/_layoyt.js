function reloadContentOrderPage() {
    $.ajax({
        url: '../Order/OrderPage',
        type: 'GET',
        success: function (result) {
            $('.renderbody').html(result); 
        }
    });
}

function reloadContentAdminOrderPage() {
    $.ajax({
        url: '../Order/AdminOrderPage',
        type: 'GET',
        success: function (result) {
            $('.renderbody').html(result);
        }
    });
}

function reloadContentAdminPage() {
    $.ajax({
        url: '../Order/AdminPage',
        type: 'GET',
        success: function (result) {
            $('.renderbody').html(result);
        }
    });
}