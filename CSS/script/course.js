var course = course || {};

course.apiUrl = "https://localhost:44393/api/course";

course.drawTable = function () {
    $.ajax({
        url: `${course.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function (data) {
            $.each(data, function (i, v) {
                $('#tbCourse>tbody').append(`
                    <tr>
                        <td>${v.courseId}</td>
                        <td>${v.courseName}</td>
                        <td>${v.startDateStr}</td>
                        <td>${v.endDateStr}</td>
                        <td></td>
                    </tr>
                `);
            })
        }
    });
}

course.init = function () {
    course.drawTable();
}


$(document).ready(function () {
    course.init();
});