var student = student || {};

student.apiUrl = "https://localhost:44393/api/student";

student.drawTable = function () {
    $.ajax({
        url: `${student.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function (data) {
            $.each(data, function (i, v) {
                $('#tbStudent>tbody').append(`
                    <tr>
                        <td>${v.studentId}</td>
                        <td>${v.fullName}</td>
                        <td>${v.gender}</td>
                        <td>${v.dobStr}</td>
                        <td>${v.email}</td>
                        <td>${v.phoneNumber}</td>                       
                        <td>${v.address}</td>
                    </tr>
                `);
            })
        }
    });
}

student.init = function () {
    student.drawTable();
}


$(document).ready(function () {
    student.init();
});