$(document).ready(function () {
    $("#tbCourse").dataTable(
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
courses.Deleted = function (courseId, courseName) {
    bootbox.confirm({
        title: '<h2 class="text-warning">Warning</h2>',
        message: `Do you want to <b class="text-danger">Delete</b> this <b class="text-info">${courseName}</b> course?`,
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
                    url: `/Course/Deleted/${courseId}`,
                    method: "PUT",
                    contentType: 'JSON',
                    success: function (data) {
                        bootbox.alert(`Delete ${courseName} success!`);
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

courses.Inprocess = function (courseId, courseName) {
    bootbox.confirm({
        title: '<h2 class="text-warning">Warning</h2>',
        message: `Do you want to <b class="text-danger">Inprocess</b> this <b class="text-info">${courseName}</b> course?`,
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
                    url: `/Course/Inprocess/${courseId}`,
                    method: "PUT",
                    contentType: 'JSON',
                    success: function (data) {
                        bootbox.alert(`Changed status ${courseName} to Inprocess success!`);
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
courses.Completed = function (courseId, courseName) {
    bootbox.confirm({
        title: '<h2 class="text-warning">Warning</h2>',
        message: `Do you want to <b class="text-danger">Completed</b> this <b class="text-info">${courseName}</b> course?`,
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
                    url: `/Course/Completed/${courseId}`,
                    method: "PUT",
                    contentType: 'JSON',
                    success: function (data) {
                        bootbox.alert(`Changed status ${courseName} to Completed success!`);
                        }, 3000);
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