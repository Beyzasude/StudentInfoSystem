function loadAcademician() {
    var id = $('#departmentDropdown').val();
    $.ajax({
        url: '/Personnel/GetAcademisionDropdown/',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ departmentId: id }),
        success: function (response) {
            var content = "";
            for (i = 0; i < response.length; ++i) {
                content +=
                    "<option value='" + response[i].Id + "'>" + response[i].Name + "</option>";
            }
            $("#AcademicianDropDown").empty();
            $("#AcademicianDropDown").append(content);
        }
    });
}

function successClick() {

    var data = new FormData();
    data.append("Name", $("#studentAddInput_Name").val());
    data.append("Surname", $("#studentAddInput_Surname").val());
    data.append("Email", $("#studentAddInput_Email").val());
    data.append("Phone", $("#studentAddInput_Phone").val());
    data.append("TC", $("#studentAddInput_Tc").val());
    data.append("Password", $("#studentAddInput_Password").val());
    data.append("Semester", $("#studentAddInput_Semester").val());
    data.append("DepartmentID", $("#departmentDropdown").val());
    data.append("AcademicianID", $("#AcademicianDropDown").val());
    data.append("SyllabusID", $("#studentAddInput_SyllabusID").val());
    data.append("Address", $("#studentAddInput_Address").val());
    data.append("ImageName", $("#formFileSm")[0].files[0]);

    $.ajax({
        url: '/Personnel/AddStudent',
        type: 'POST',
        contentType: false,
        processData: false,
        /*data: JSON.stringify({ data }),*/
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