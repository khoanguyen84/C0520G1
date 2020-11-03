var course = course || {};
course.apiUrl = "https://localhost:44393/api/course";
course.drawTable = function () {
    $.ajax({
        url: `${course.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function (data) {
            $('#tbCourse>tbody').empty()
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
course.openAddEditCourse = function () {
    course.reset();
    $('#addEditCourse').appendTo("body").modal('show');
};
course.reset = function () {
    $('#CourseName').val("");
}
course.save = function () {
    var saveObj = {};
    saveObj.CourseName = $('#CourseName').val();
    saveObj.StartDate = $('#StartDate').val();
    saveObj.EndDate = $('#EndDate').val();
    $.ajax({
        url: `${course.apiUrl}/save`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditCourse').modal('hide');
            alert('Success!');
            course.drawTable();
        }
    });
}
course.complete = function (id, input) {
    var result = confirm('Bạn muốn thay đổi trạng thái của khóa học có ID = ' + id)
    if (result) {
        $.ajax({
            url: `${course.apiUrl}/complete/${id}`,
            method: "GET",
            dataType: "json",
            success: function () {
                alert('Thành công!');
            },
        });
    } else {
        input.checked = !input.checked;
        alert("Đã hủy")
    };
};
course.init = function () {
    course.drawTable();
}
$(document).ready(function () {
    course.init();
});