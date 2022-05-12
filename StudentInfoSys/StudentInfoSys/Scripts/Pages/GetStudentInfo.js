function loadData(id) {
    $.ajax({
        url: '/Academician/GetStudentInfoPopUp/',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ id: id }),
        success: function (response) {
            let content = "<tr>" +
                "<td>" + response.Id + "</td>" +
                "<td>" + response.Name + "</td>" +
                "<td>" + response.Surname + "</td>" +
                "<td>" + response.Email + "</td>" +
                "<td>" + response.Phone + "</td>" +
                "<td>" + response.Address + "</td>" +
                "<td>" + response.Tc + "</td>" +
                "<td>" + response.Semester + "</td>" +
                "<td>" + response.AcademicianName + "</td>" +
                "<td>" + response.DepartmentName + "</td></tr>";

            $("#student-info-body").empty();
            $("#student-info-body").append(content);
            $('#myModal').modal('show');
        }
    });
}