var course = course || {};
course.delete = (id) => {
    bootbox.confirm({
        title: "Delete Course?",
        message: "<p class=\"text-danger\">Do you want to delete this course.</p>",
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
                    url: `/Course/Delete/${id}`,
                    method: 'GET',
                    dataType: 'JSON',
                    success: function (data) {
                        console.log(data),
                        bootbox.alert(data.result.message),
                        window.location.href = "/Course/Index"
                    }
                });
            }
        }
    });
}



$(document).ready(function () {
    $('#tbCourse').dataTable({
        "columnDefs": [
            {
                "targets": 0,
                "searchable": false,
            },
            {
                "targets": 5,
                "orderable": false,
                "searchable": false
            },
        ]
    }
    );
});
