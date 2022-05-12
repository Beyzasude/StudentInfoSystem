function successClick() {
    let id = $("#academicianResult_Id").val();
    let name = $("#academicianResult_Name").val();
    let surname = $("#academicianResult_Surname").val();
    let email = $("#academicianResult_Email").val();
    let phone = $("#academicianResult_Phone").val();
    let departmentID = $("#departmentDropdown").val();

    $.ajax({
        url: '/Personnel/UpdateAcademician',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ Id: id, Name: name, Surname: surname, Email: email, Phone: phone, DepartmentID: departmentID }),
        success: function (response) {
            if (response == false) {
                iziToast.error({ timeout: 5000, icon: 'fa fa-chrome', message: 'İşlem Tamamlanamadı!' });
            }
            else
                iziToast.success({ timeout: 5000, icon: 'fa fa-chrome', message: 'İşlem Başarıyla Kaydedildi!' });
        }
    });
}