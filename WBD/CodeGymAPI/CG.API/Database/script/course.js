var Teacher = Teacher || {};

Teacher.apiUrl = "https://localhost:44393/api/Teacher";

Teacher.drawTable = function() {
    $.ajax({
        url: `${course.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function(data) {
            $.each(data, function (i, v) {
                $('#tbTeacher>tbody').append(`
                    <tr>
                        <th>${v.TeacherId}</th>
                        <th>${v.Fullname}</th>
                        <th>${v.Dob}</th>
                        <th>${v.Email}</th>
                        <th>${v.PhoneNumber}</th>
                        <th>${v.Level}</th>
                        <th>${v.Address}</th>
                        <th>${v.avatar}</th>
                        <th>${v.status}</th>
                        <th>${v.createDate}</th>
                        <th>${v.createBy}</th>
                        <th>${v.modifiedDate}</th>
                        <th>${v.modifiedBy}</th>
                    </tr>
                `);
            })
        }
    });
}

Teacher.init = function() {
    course.drawTable();
}


$(document).ready(function() {
    Teacher.init();
});