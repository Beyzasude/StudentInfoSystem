////function loadAcademician() {
////    var id = $('#departmentDropdown').val();
////    $.ajax({
////        url: '/Personnel/GetAcademisionDropdown/',
////        type: 'POST',
////        contentType: 'application/json',
////        data: JSON.stringify({ departmentId: id }),
////        success: function (response) {
////            var content = "";
////            for (i = 0; i < response.length; ++i) {
////                content +=
////                    "<option value='" + response[i].Id + "'>" + response[i].Name + "</option>";
////            }
////            $("#AcademicianDropDown").empty();
////            $("#AcademicianDropDown").append(content);
////        }
////    });
////}

function successClick() {

    var data = new FormData();
    data.append("Name", $("#academicianAddInput_Name").val());
    data.append("Surname", $("#academicianAddInput_Surname").val());
    data.append("Email", $("#academicianAddInput_Email").val());
    data.append("Phone", $("#academicianAddInput_Phone").val());
    data.append("Password", $("#academicianAddInput_Password").val());
    data.append("Semester", $("#studentAddInput_Semester").val());
    data.append("DepartmentID", $("#departmentDropdown2").val());
    data.append("SyllabusID", $("#academicianAddInput_SyllabusID").val());
    data.append("ImageName", $("#fileImage")[0].files[0]);

    $.ajax({
        url: '/Personnel/AddAcademician',
        type: 'POST',
        contentType: false, 
        processData: false,
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


//function successClick() {
//    let name = $("#academicianAddInput_Name").val();
//    let surname = $("#academicianAddInput_Surname").val();
//    let email = $("#academicianAddInput_Email").val();
//    let phone = $("#academicianAddInput_Phone").val();
//    let password = $("#academicianAddInput_Password").val();
//    let departmentID = $("#departmentDropdown2").val();
//    let syllabusID = $("#academicianAddInput_SyllabusID").val();


//    $.ajax({
//        url: '/Personnel/AddAcademician',
//        type: 'POST',
//        contentType: 'application/json',
//        data: JSON.stringify({ Name: name, Surname: surname, Email: email, Phone: phone,  Password: password, DepartmentID: departmentID,  syllabusID: syllabusID }),
//        success: function (response) {
//            if (response == false) {
//                iziToast.error({ timeout: 5000, icon: 'fa fa-chrome', /*title: 'OK',*/ message: 'İşlem Tamamlanamadı!' });
//            }
//            else
//                iziToast.success({ timeout: 5000, icon: 'fa fa-chrome', /*title: 'OK',*/ message: 'İşlem Başarıyla Kaydedildi!' });
//        }
//    });
//}