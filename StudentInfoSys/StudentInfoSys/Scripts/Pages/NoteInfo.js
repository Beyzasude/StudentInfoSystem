
iziToast.settings({
    timeout: 30000, // default timeout
    resetOnHover: true,
    // icon: '', // icon class
    transitionIn: 'flipInX',
    transitionOut: 'flipOutX',
    position: 'topRight', // bottomRight, bottomLeft, topRight, topLeft, topCenter, bottomCenter, center
    onOpen: function () {
        console.log('callback abriu!');
    },
    onClose: function () {
        console.log("callback fechou!");
    }
});

// info
$('infoClick').click(function () {
    iziToast.info({ position: "center", title: 'Hello', message: 'iziToast.info()' });
}); // ! click

// success
//$('#successClick').click(function () {
//    iziToast.success({ timeout: 5000, icon: 'fa fa-chrome', title: 'OK', message: 'İşlem Başarıyla Kaydedildi.' });
//}); // ! .click

// warning
$('#warningClick').click(function () {
    iziToast.warning({ position: "bottomLeft", title: 'Caution', message: '日本語環境のテスト' });
});

// error
$('#errorClick').click(function () {
    iziToast.error({ title: 'Error', message: 'Illegal operation' });
});

// custom toast
$('#customClick').click(function () {

    iziToast.show({
        color: 'dark',
        icon: 'fa fa-user',
        title: 'Hey',
        message: 'Custom Toast!',
        position: 'center', // bottomRight, bottomLeft, topRight, topLeft, topCenter, bottomCenter
        progressBarColor: 'rgb(0, 255, 184)',
        buttons: [
            [
                '<button>Ok</button>',
                function (instance, toast) {
                    alert("Hello world!");
                }
            ],
            [
                '<button>Close</button>',
                function (instance, toast) {
                    instance.hide({
                        transitionOut: 'fadeOutUp'
                    }, toast);
                }
            ]
        ]
    });

}); // ! .click()

$('#any').click(function () {
    iziToast.error({
        title: 'Errorカラー',
        message: 'iziToast.error()'
    });
});

$(document).ready(function () {
    var id = getParameterByName('id');
    $.ajax({
        url: '/Academician/GetNoteInfo/' + id,
        type: 'POST',
        contentType: 'application/json',
        data: {},
        success: function (response) {
            var content = "";
            for (i = 0; i < response.length; ++i) {
                content =
                    "<tr class='notes-tr'><td>" + response[i].StudentName + "</td>" +
                    "<td>" + response[i].StudentSurname + "</td>" +
                    "<td><input type='number' name='Note1' class = 'form-control' value='" + response[i].Note1 + "'/></td>" +
                    "<td><input type='number' name='Note2' class = 'form-control' value='" + response[i].Note2 + "'/>" +
                    "<input type='hidden' name='StudentLectureID' value='" + response[i].StudentLectureID + "'/></td></tr>";
                $("#notes-tbody").append(content);
            }

            
        }
    });
})

function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}


$("#successClick").click(function () {
    var list = [];
    $("#notes-tbody tr").each(function () {
        list.push({
            Note1: $(this).find("[name='Note1']").val(),
            Note2: $(this).find("[name='Note2']").val(),
            StudentLectureID: $(this).find("[name='StudentLectureID']").val()
        });
    });

    $.ajax({
        url: '/Academician/AddNoteInfo',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(list),
        success: function (response) {
            iziToast.success({ timeout: 5000, icon: 'fa fa-chrome', /*title: 'OK',*/ message: 'İşlem Başarıyla Kaydedildi!' });
        }
    });
})

