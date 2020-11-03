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
courses.delete = function (courseId, courseName) {
    bootbox.confirm({
        title: '<h2 class="text-danger">Warning</h2>',
        message: `Do you want to <b class="text-primary">Delete</b> this <b class="text-success">${courseName}</b> course?`,
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
                    url: `/Course/Delete/${courseId}`,
                    method: "PATCH",
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

courses.changeCourseStatusToInProcess = function (courseId, courseName) {
    bootbox.confirm({
        title: '<h2 class="text-danger">Warning</h2>',
        message: `Do you want to <b class="text-primary">Inprocess</b> this <b class="text-success">${courseName}</b> course?`,
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
                    url: `/Course/ChangeCourseStatusToInProcess/${courseId}`,
                    method: "PATCH",
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
courses.changeCourseStatusToCompleted = function (courseId, courseName) {
    bootbox.confirm({
        title: '<h2 class="text-danger">Warning</h2>',
        message: `Do you want to <b class="text-primary">Completed</b> this <b class="text-success">${courseName}</b> course?`,
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
                    url: `/Course/ChangeCourseStatusToCompleted/${courseId}`,
                    method: "PATCH",
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