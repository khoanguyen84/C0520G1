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
                        <td>  <a href="javascript:;" onclick="module.GetModuleId(${v.moduleId})" class="text-warning"><i class ="fas fa-edit"></i></a> 
                            <a href="javascript:;"class="text-danger" onclick="module.DeleteModule(${v.moduleId},'${v.moduleName }')"><i class ="fas fa-trash"></i></a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}

module.openModal = function () {
    module.resetForm();
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
                bootbox.alert(`<h2 class="text-success">${response.data.message}</h2>`);
                if (response.data.moduleId > 0) {
                    $('#addEditModuleModal').modal('hide');
                    module.showData();
                }
            }
        });
    }
}
module.GetModuleId = function (id) {
   
    $.ajax({
        url: `module/get/${id}`,
        method: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            console.log(data);
            $('#ModuleId').val(data.moduleId);
            $('#ModuleName').val(data.moduleName);
            $('#Duration').val(data.duration);
            $('#Status').val(data.status);           
            $('#addEditModuleModal').find('.modal-title').text('Update Module');
            $('#addEditModuleModal').modal('show');
        }
    });

};
module.resetForm = function () {
    $('#ModuleName').val('');
    $('#Duration').val('');
    $('#Status').val('');   
    $('#ModuleId').val(0);
    $('#addEditModuleModal').find('.modal-title').text('Create New User');
  
}
module.DeleteModule = function (moduleId, moduleName) {
    bootbox.confirm({
        title: '<h1 class = "text-danger">Warning</h1>',
        message: `Do you want to delete ${moduleName}?`,
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
                    url: `/Module/DeleteCourse/${moduleId}`,
                    method: "GET",
                    contentType: 'JSON',
                    success: function (data) {
                        console.log(data);
                        if (data) {
                            window.location.href = `/Module/Index`;
                        }
                    }
                });
            }
        }
    });
}


module.init = function () {
    module.showData();
    module.initStatus();
}

$(document).ready(function () {
    module.init();
});