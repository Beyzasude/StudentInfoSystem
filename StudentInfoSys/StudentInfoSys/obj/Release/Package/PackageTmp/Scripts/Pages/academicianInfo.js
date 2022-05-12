
$(document).ready(function () {
    $.ajax({
        url: '/Academician/GetListAcademicianInfo',
        type: 'POST',
        contentType: 'application/json',
        data: {},
        success: function (response) {
            var content = "<td>" + response.Name + "</td>" +
                "<td>" + response.Surname + "</td>" +
                "<td>" + response.Email +"</td>" +
                "<td>" + response.Phone +"</td>" +
                "<td>" + response.DepartmentName + "</td>";

            $(".academician-info-tbl").append(content);
        }
    });
    
})


