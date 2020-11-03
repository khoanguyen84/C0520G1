var course = course || {};
course.apiUrl = "https://localhost:44393/api/course";
course.complete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa khóa học này không?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Không'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Có'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `${course.apiUrl}/complete/${id}`,
                    method: "PUT",
                    dataType: "json",
                    success: function () {
                        alert('Thành công!');
                        window.location.replace("https://localhost:44397/");
                    },
                });
            }
        }
    });
}