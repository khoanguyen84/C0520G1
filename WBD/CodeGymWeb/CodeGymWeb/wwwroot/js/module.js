var module = {} || module;

module.showData = function () {
    $.ajax({
        url: '/module/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbModule>tbody').empty();
            $.each(response.data, function (i, v) {
                $('#tbModule>tbody').append(
                    `<tr>
                        <td>${v.moduleId}</td>
                        <td>${v.moduleName}</td>
                        <td>${v.duration}</td>
                        <td>${v.statusName}</td>
                        <td>
                            <button class="btn btn-info"
                            onclick="module.edit(${v.moduleId},'${v.moduleName}',${v.duration},${v.status})">Edit</button>
                            <a href="javascript:void(0)" onclick="module.delete(${v.moduleId},'${v.moduleName}')"
                                class="btn btn-danger"> Delete
                            </a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}

module.edit = function (moduleId, moduleName, duration, status) {
    $("#ModuleName").val(moduleName);
    $("#Duration").val(duration);
    $("#ModuleId").val(moduleId);
    module.initStatus(status);
    module.openModal();
}

module.delete = function (moduleId, moduleName) {
    bootbox.confirm({
        message: "Delete <span class='text-danger'>" + moduleName + "</span> ?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/module/delete/${moduleId}`,
                    method: 'GET',
                    dataType: 'json',
                    success: function (response) {
                        if (response.data.message == "success") {
                            window.location.href = "/module/Index/";
                        }
                        else {
                            bootbox.alert({
                                message: "Something wrong",
                                callback: function () {
                                    window.location.href = "/module/Index/";
                                }
                            })
                        }
                    }
                });
            }
        }
    });
}

module.openModal = function () {
    $('#addEditModuleModal').modal('show');
}

module.initStatus = function (defaultStatus) {
    $.ajax({
        url: '/module/status/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#Status').empty();
            $.each(response.data, function (i, v) {
                $('#Status').append(
                    `<option value=${v.id}>${v.name}</option>`
                );
                $('#Status').val(defaultStatus);
            });
        }
    });
}

module.save = function () {
    if ($('#frmAddEditModule').valid()) {
        var saveObj = {};
        saveObj.moduleId = parseInt($('#ModuleId').val());
        saveObj.moduleName = $('#ModuleName').val();
        saveObj.duration = parseInt($('#Duration').val());
        saveObj.status = parseInt($('#Status').val());
        $.ajax({
            url: '/module/save',
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                bootbox.alert(response.data.message);
                if (response.data.moduleId > 0) {
                    $('#addEditModuleModal').modal('hide');
                    $("#frmAddEditModule").trigger("reset");
                    module.showData();
                }
            }
        });
    }
}

$('#closeButton').on('click', function () {
    //Close Modal
    $(".modal").modal("hide");
    //Reset Values
    $("#frmAddEditModule").trigger("reset");
});

module.init = function () {
    module.showData();
    module.initStatus();
}

$(document).ready(function () {
    module.init();
});