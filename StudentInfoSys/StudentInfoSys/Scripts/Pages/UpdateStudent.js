////function Myfunction() {
////    iziToast.success({ timeout: 5000, icon: 'fa fa-chrome', message: 'İşlem Başarıyla Kaydedildi.' });
////}

$('form').submit(function (event) {
    event.preventDefault();

    var formdata = $('#demoForm');
    //If you are uploading files, then you need to use "FormData" instead of "serialize()" method. 
    //var formdata = new FormData($('#demoForm').get(0)); 

    $.ajax({
        type: "POST",
        url: "/Personnel/UpdateStudent",
        contentType: "application/json; charset=utf-8",
        data: { 'studentResult': formdata },

        /* If you are uploading files, then processData and contentType must be set to 
        false in order for FormData to work (otherwise comment out both of them) */
        processData: false, //For posting uploaded files
        contentType: false, //For posting uploaded files
        //

        //Callback Functions (for more information http://api.jquery.com/jquery.ajax/)
        beforeSend: function () {
            //e.g. show "Loading" indicator
        },
        error: function (response) {
            $("#error_message").html(data);
        },
        success: function (data, textStatus, XMLHttpRequest) {
            $('#result').html(data); //e.g. display message in a div
        },
        complete: function () {
            //e.g. hide "Loading" indicator
        },
    });
});

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
    let id = $("#studentResult_Id").val();
    let name = $("#studentResult_Name").val();
    let surname = $("#studentResult_Surname").val();
    let email = $("#studentResult_Email").val();
    let phone = $("#studentResult_Phone").val();
    let address = $("#studentResult_Address").val();
    let tc = $("#studentResult_Tc").val();
    let semester = $("#studentResult_Semester").val();
    let academicianID = $("#AcademicianDropDown").val();
    let departmentID = $("#departmentDropdown").val();

    $.ajax({
        url: '/Personnel/UpdateStudent',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ Id: id, Name: name, Surname: surname, Email: email, Phone: phone, Address: address, Tc: tc, Semester: semester, AcademicianID: academicianID, DepartmentID: departmentID }),
        success: function (response) {
            if (response == false) {
                iziToast.error({ timeout: 5000, icon: 'fa fa-chrome', message: 'İşlem Tamamlanamadı!' });
            }
            else
                iziToast.success({ timeout: 5000, icon: 'fa fa-chrome', message: 'İşlem Başarıyla Kaydedildi!' });
        }
    });
}

//$("#update-btn").click(function () {
//    let id = $("#Id").val();
//    let name = $("#Name").val();
//    let surname = $("#Surname").val();
//    let email = $("#Email").val();
//    let phone = $("#Phone").val();
//    let address = $("#Address").val();
//    let tc = $("#Tc").val();
//    let semester = $("#Semester").val();
//    let academicianID = $("#AcademicianID").val();
//    let departmentID = $("#DepartmentID").val();


//    $.ajax({
//        url: '/Personnel/UpdateStudent',
//        type: 'POST',
//        contentType: 'application/json',
//        data: JSON.stringify({ Id: id, Name: name, Surname: surname, Email: email, Phone: phone, Address: address, Tc: tc, Semester: semester, AcademicianID: academicianID, DepartmentID: departmentID }),
//        success: function (response) {
//            if (response == false) {
//                iziToast.error({ timeout: 5000, icon: 'fa fa-chrome', message: 'İşlem Tamamlanamadı!' });
//            }
//            else {
//                iziToast.success({ timeout: 5000, icon: 'fa fa-chrome', message: 'İşlem Başarıyla Kaydedildi!' });
//            }
//        }
//    });
//})