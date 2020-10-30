var Course = Course || {};

Course.apiUrl = "https://localhost:44393/api/course";

Course.drawTable = function() {
    $.ajax({
        url: `${Course.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function(data) {
            $.each(data, function (i, v) {
                $('#tbCourse>tbody').append(`
                    <tr>
                        <th>${v.courseId}</th>
                        <th>${v.courseName}</th>
                        <th>${v.startDateStr}</th>
                        <th>${v.endDateStr}</th>
                        <th>${v.statusName}</th>
                        <th></th>
                    </tr>
                `);
            })
        }
    });
}

Course.detail = function(id){
    $.ajax({
        url: `${Course.apiUrl}/get/${id}`,
        method : "GET",
        dataType: "JSON",
        success: function(data){
            $("#deltail").append(`
            <div class="card-header text-center">
                    <h3>Course Id: ${data.courseId}</h3>
                    <h3>Course Name: ${data.courseName}</h3>
                </div>
                <div class="card-body text-center">
                    <h3>Status:${data.statusName}</h3>
                    <h3>Start Date: ${data.startDateStr}</h3>
                    <h3>End Date: ${data.endDateStr}</h3>
                </div>
                <div class="card-footer text-center">
                    <a asp-controller="Course" asp-action="Index" class="btn btn-warning">Back</a>
                    <a asp-controller="Course" asp-action="Update" asp-route-id="@Model.CourseId" class="btn btn-primary">Edit</a>
                </div>
            `);
        }
    });
}

Course.init = function() {
    Course.drawTable();
}

$(document).ready(function() {
    Course.init();
});

$(document).ready(function(id) {
    Course.detail(id);
});