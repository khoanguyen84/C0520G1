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
                            <a href="javascript:void(0);" title="Edit Module"
                                onclick="module.Edit(${v.moduleId},'${v.moduleName}',${v.duration},'${v.status}')">
                                <i class="far fa-eye"></i>
                            </a>
                                
                            <a onclick="module.Delete(${v.moduleId}, '${v.moduleName }')"
                               href="javascript:void(0);" title="Delete Module" >
                               <i class='fas fa-trash'></i>
                            </a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}
module.Delete= function (id, name) {
    bootbox.confirm({
        title: 'Confirm!',
        message: "Do you want to delete " + name,
        buttons: {
            cancel: function () {
                $.alert('Canceled!');
            }
        }, callback: function (result) {
            $.confirm({
                title: 'Message',
                content: "Completed delete " + name,
                buttons: {
                    somethingElse: {
                        btnClass: 'btn-blue',
                        text: 'Ok',
                        action: function () {
                            window.location.href = "module/Delete?id=" + id;
                        }
                    }
                }
            });
        }
    });
};

module.Edit = function (moduleId, moduleName, duration, status) {
    $('#ModuleId').val(moduleId);
    $('#ModuleName').val(moduleName);
    $('#Duration').val(duration);
    module.initStatus(status);
    module.openModal();
    console.log("texxt  " + status )
}

//EDIT c1
    /*< a href = "javascript:void(0);" title = "Edit Module"
onclick = "module.Edit(${v.moduleId})"class="btn btn-warning" >
    Edit
                            </a >*/
/*module.Edit = function (id) {
    $.ajax({
        url: `https://localhost:44393/api/module/get/${id}`,
        method: 'GET',
        dataType: 'JSON',
        success: function (data) {
            $('#ModuleId').val(data.moduleId);        
            $('#ModuleName').val(data.moduleName);
            $('#Duration').val(data.duration);
            $('#StatusName').val(data.statusName);
            module.openModal();
            console.log("text id "+id)
        }
             
    });
}*/


module.openModal = function () {
    $('#addEditModuleModal').modal('show');
}

module.initStatus = function (status) {
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
                if (status != null) {
                    $('#Status').val(status);
                }
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
                    module.showData();
                }
            }
        });
    }
}

module.init = function () {
    module.showData();
    module.initStatus();
}

$(document).ready(function () {
    module.init();
});