$(document).ready(function () {
    $("#tbTables").dataTable(
        {
            "columnDefs": [
                {
                    "targets": 5,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});
var courses = courses || {};
courses.DeleteCourse = function (courseId, courseName) {
    bootbox.confirm({
        title:'<h1 class = "text-danger">Warning</h1>',
        message: `Do you want to delete ${courseName}?`,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Yes'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Course/DeleteCourse/${courseId}`,
                    method: "GET",
                    contentType: 'JSON',
                    success: function (data) {
                        console.log(data);
                        if (data) {
                            window.location.href = `/Course/Index`;
                        }
                    }
                });
            }
        }
    });
}

courses.IsCompleted = function (courseId, courseName) {
    bootbox.confirm({
        title: "Warning",
        message: `Do you want to Complete this ${courseName}?`,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Yes'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Course/IsCompleted/${courseId}`,
                    method: "GET",
                    contentType: 'JSON',
                    success: function (data) {
                        console.log(data);
                        if (data) {
                            window.location.href = `/Course/Index`;
                        }
                    }
                });
            }
        }
    });
}
courses.ChangeSTT = function (courseId, courseName) {
    bootbox.confirm({
        title: "Warning",
        message: `Do you want to Inprocess ${courseName}?`,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Yes'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Course/ChangeSTT/${courseId}`,
                    method: "GET",
                    contentType: 'JSON',
                    success: function (data) {
                        console.log(data);
                        if (data) {
                            window.location.href = `/Course/Index`;
                        }
                    }
                });
            }
        }
    });
}