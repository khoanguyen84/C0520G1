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
                        <td><a href="javascript:void(0);" class="btn btn-success" 
                        onclick="module.Update(${v.moduleId},'${v.moduleName}',${v.duration},'${v.statusName}')">Edit</a>
                        <a href="javascript:void(0);" class="btn btn-warning"
                        onclick="module.Delete(${v.moduleId},'${v.moduleName}')">Delete</a></td>
                    </tr>`
                );
            });
        }
    });
}

module.Update = function (moduleId, moduleName, duration, statusName) {
    $('#ModuleId').val(moduleId);
    $('#ModuleName').val(moduleName);
    $('#Duration').val(duration);
    $('#Status').val(statusName);
    module.initStatus();
    module.openModal();

}

module.openModal = function () {
    $('#addEditModuleModal').modal('show');
}

module.initStatus = function () {
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
            });
        }
    });
}

module.save = function () {
    if ($('#formAddEditModule').valid()) {
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
                    $('#formAddEditModule').trigger('reset');
                    module.showData();

                }
            }
        });
    }
}

$('#Close').on('click', function () {
    $('#addEditModuleModal').modal('hide');
    $('#formAddEditModule').trigger('reset');
})


module.init = function () {
    module.showData();
    module.initStatus();
}

$(document).ready(function () {
    module.init();
});

module.Delete = function (id, name) {
    bootbox.confirm({
        message: "Do you want to Delete ? <span class='text-danger'>" + name + "</span>",
        buttons: {
            cancel: {
                label: 'No',
                className: 'btn-danger'
            },
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            }
        },
        callback: function (result) {
            if (result) {
                module.showData();
                //window.location.href = "Module/Delete?id=" + id;
                bootbox.alert("Delete Completed ");
            }
        }
    });
};