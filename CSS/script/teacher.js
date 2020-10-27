var teacher = teacher || {};

teacher.apiUrl = "https://localhost:44393/api/teacher";

teacher.drawTable = function () {
    $.ajax({
        url: `${teacher.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function (data) {
            $.each(data, function (i, v) {
                $('#tbTeacher>tbody').append(`
                    <tr>
                        <td>${v.teacherId}</td>
                        <td>${v.fullName}</td>
                        <td>${v.gender}</td>
                        <td>${v.email}</td>
                        <td>${v.phoneNumber}</td>
                        <td>${v.level}</td>
                        <td>${v.address}</td>
                        <td>${v.avata}</td>
                        <td>${v.status}</td>
                    </tr>
                `);
            })
        }
    });
}

teacher.init = function () {
    teacher.drawTable();
}

$(document).ready(function () {
    teacher.init();
});