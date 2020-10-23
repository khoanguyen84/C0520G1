var Teacher = Teacher || {};

Teacher.apiUrl = "https://localhost:44393/api/Teacher";

Teacher.drawTable = function() {
    $.ajax({
        url: `${Teacher.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function(data) {
            $.each(data, function (i, v) {
                $('#tbTeacher>tbody').append(`
                    <tr>
                        <th>${v.teacherId}</th>
                        <th>${v.fullName}</th>
                        <th>${v.gender}</th>
                        <th>${v.date}</th>
                        <th>${v.email}</th>
                        <th>${v.phoneNumber}</th>
                        <th>${v.level}</th>
                        <th>${v.address}</th>
                        <th>${v.avatar}</th>
                        <th>${v.status}</th>
                        <th>${v.createDate}</th>
                        <th>${v.createBy}</th>
                        <th>${v.dateTimeOffset}</th>
                        <th>${v.modifiedBy}</th>
                    </tr>
                `);
            })
        }
    });
}

Teacher.init = function() {
    Teacher .drawTable();
}


$(document).ready(function() {
    Teacher.init();
});