
$("#btnLogin").click(function () {
    var dataObject = JSON.stringify({
        'email': $("#email").val(),
        'password': $("#password").val()
    });
    $.ajax({
        url: '/Login/StudentLogin',
        type: 'POST',
        contentType: 'application/json',
        data: dataObject,
        success: function (response) {
            if (response == "success")
                window.location.href = '/Student/Index';
            else
                $("#alert").html(response);
        }
    });
});