function successClick() {

    var data = new FormData();

    data.append("ImageName", $("#formFileSm")[0].files[0]);

    $.ajax({
        url: '/Student/UpdateImageFile',
        type: 'POST',
        /* contentType: 'application/json',*/
        contentType: false,
        processData: false,
        /* data: JSON.stringify( data),*/
        data: data,
        success: function (response) {
            if (response == false) {
                iziToast.error({ timeout: 5000, icon: 'fa fa-chrome', message: 'İşlem Tamamlanamadı!' });
            }
            else
                iziToast.success({ timeout: 5000, icon: 'fa fa-chrome', message: 'İşlem Başarıyla Kaydedildi!' });
        }
    });
}