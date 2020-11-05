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
                             <a href='/module/details/${v.moduleId}' class="text-primary ml-2"><i class="fas fa-eye"></i></a>
                             <a href="javascript:;" class="text-warning  ml-2" onclick="module.edit(${v.moduleId})"><i class='fas fa-edit'></i></a>
                             <a href="javascript:;" class='text-danger ml-2' onclick="module.delete(${v.moduleId},'${v.moduleName}')"><i class='fas fa-trash'></i></a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}

module.delete = function (moduleId, moduleName) {
    bootbox.confirm({
        title: '<h2 class="text-danger">Warning</h2>',
        message: `Do you want to <b class="text-primary">Delete</b> this <b class="text-success">${moduleName}</b> module?`,
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
                    url: `/module/delete/${moduleId}`,
                    method: 'PATCH',
                    dataType: 'JSON',
                    contentType: 'application/json',
                    success: function (response) {
                        bootbox.alert(`<h4 class="alert alert-danger">${response.data.message} !!!</h4>`);
                        if (response.data.moduleId > 0) {
                            $('#addEditModuleModal').modal('hide');
                            module.showData();
                        }
                    }
                });
            }
        }
    });
}

module.edit = function (id) {
    $.ajax({
        url: `/module/get/${id}`,
        method: 'GET',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (response) {
            $('#ModuleId').val(response.data.moduleId);
            $('#ModuleName').val(response.data.moduleName);
            $('#Duration').val(response.data.duration);
            $('#Status').val(response.data.status);
            $('#addEditModuleModal').find('.modal-title').text('Update Module');
            $('#addEditModuleModal').modal('show');
            document.getElementById('msg').style.display = 'none';
        }
    });
    
}

module.openModal = function () {
    module.resetForm();
    document.getElementById('msg').style.display = 'none';
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
    if ($('#fromAddEditModule').valid()) {
        var changeObj = {};
        var checkSave = false;
        var saveObj = {};
        saveObj.moduleId = parseInt($('#ModuleId').val());
        saveObj.moduleName = $('#ModuleName').val();
        saveObj.duration = parseInt($('#Duration').val());
        saveObj.status = parseInt($('#Status').val());
        $.ajax({
            url: `/module/get/${saveObj.moduleId}`,
            method: 'GET',
            dataType: 'JSON',
            contentType: 'application/json',
            success: function (response) {
                console.log(response);
                if (response.data.moduleName != saveObj.moduleName) {
                    changeObj.moduleName = response.data.moduleName;
                    checkSave = true;
                };
                if (response.data.duration != saveObj.duration) {
                    changeObj.duration = response.data.duration;
                    checkSave = true;
                };
                if (response.data.status != saveObj.status) {
                    changeObj.status = response.data.status;
                    checkSave = true;
                };
                if (checkSave) {
                    $.ajax({
                        url: '/module/save',
                        method: 'POST',
                        dataType: 'JSON',
                        contentType: 'application/json',
                        data: JSON.stringify(saveObj),
                        success: function (response) {
                            console.log(response);
                            bootbox.alert(`<h4 class="alert alert-danger">${response.data.message} !!!</h4>`);
                            if (response.data.moduleId > 0) {
                                $('#addEditModuleModal').modal('hide');
                                module.showData();
                            }
                        }
                    });
                }
                else {
                    document.getElementById('msg').innerHTML = 'You are not doing new any value !!!';
                    document.getElementById('msg').style.display = 'block';
                    //$('.msg').text('You are not doing new any value !!!');
                    //$('.msg').removeAttr("style").hide();
                    //$('.msg').show();
                    //bootbox.alert(`<h4 class="alert alert-danger">You are not doing new any value !!!</h4>`);
                }
            }
        });
    }
}

//module.save = function () {
//    if ($('#fromAddEditModule').valid()) {
//        var saveObj = {};
//        saveObj.moduleId = parseInt($('#ModuleId').val());
//        saveObj.moduleName = $('#ModuleName').val();
//        saveObj.duration = parseInt($('#Duration').val());
//        saveObj.status = parseInt($('#Status').val());
//        $.ajax({
//            url: '/module/save',
//            method: 'POST',
//            dataType: 'JSON',
//            contentType: 'application/json',
//            data: JSON.stringify(saveObj),
//            success: function (response) {
//                bootbox.alert(`<h4 class="alert alert-danger">${response.data.message} !!!</h4>`);
//                if (response.data.moduleId > 0) {
//                    $('#addEditModuleModal').modal('hide');
//                    module.showData();
//                }
//            }
//        });
//    }
//}
module.resetForm = function () {
    //var classError = document.getElementsByClassName('error');
    //for (let i = 0; i < classError.length; i++){
    //    let item = classError[i];
    //    item.classList.remove('error');
    //}
    $('#ModuleId').val(0);
    $('#ModuleName').val('');
    $('#Duration').val(0);
    $('#Status').val(1);
    $('#addEditModuleModal').find('.modal-title').text('Create New Module');
};

module.init = function () {
    module.showData();
    module.initStatus();
}

$(document).ready(function () {
    module.init();
});