var module = {} || module;

module.showData = function () {
    $.ajax({
        url: '/module/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbModule>tbody').empty();
            $.each(response.data, function (i, v) {
                var _class = "";
                v.status == 1 ? _class = "btn btn-primary" : (v.status == 2 ? _class = "btn btn-success" : (v.status == 3 ? _class = "btn btn-danger" : "btn btn-warning"));
                var actions = "";
                switch (v.status) {
                    case 2:
                        {
                            actions = `<a href='#' onclick='module.editmodal(${v.moduleId})'><i class='fas fa-edit'></i></a>
                            <a href='#' onclick ='module.inactive(${v.moduleId})'><i class='fas fa-check-circle'></i></a>`;
                            break;
                        }
                    case 1:
                        {
                            actions = `<a href='#' onclick ='module.delete(${v.moduleId})'><i class='fas fa-trash'></i></a>
                            <a href='#' onclick='module.editmodal(${v.moduleId})'><i class='fas fa-edit'></i></a>
                            <a href='#' onclick ='module.active(${v.moduleId})'><i class='far fa-play-circle'></i></a>`;
                            break;
                        }
                }
                $('#tbModule>tbody').append(
                    `<tr>
                        <td>${v.moduleId}</td>
                        <td>${v.moduleName}</td>
                        <td>${v.duration}</td>
                        <td><span class="${_class}">${v.statusName}</span></td>
                        <td><a href="#" onclick ='module.detail(${v.moduleId})'><i class="fas fa-eye"></i></a> ${actions}</td>
                    </tr>`
                );
            });
        }
    });
}

module.openModal = function () {
    $('#addEditModuleModal').modal('show');
}

module.editmodal = function (id) {
    $.ajax({
        url: `/module/update/${id}`,

        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#ModuleId').val(response.data.moduleId);
            $('#ModuleName').val(response.data.moduleName);
            $('#Duration').val(response.data.duration);
            $('#Status').val(response.data.status);
        }
    });
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
                bootbox.alert(response.data.message);
                if (response.data.moduleId > 0) {
                    $('#addEditModuleModal').modal('hide');
                    module.showData();
                }
            }
        });
    }
}



module.act = function (id, status, stringmessage) {
    bootbox.confirm({
        title: '<h3>Message</h3>',
        message: stringmessage,
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
                var change = {};
                change.moduleId = parseInt(id),
                    change.status = parseInt(status),
                    change.modifiedBy = parseInt(1)
                $.ajax({
                    url: '/module/change',
                    method: 'PUT',
                    dataType: 'JSON',
                    contentType: 'application/json',
                    data: JSON.stringify(change),
                    success: function (response) {
                        bootbox.alert(response.data.message);
                        if (response.data.moduleId > 0) {
                            //window.location.href = `/Module/Index`;
                            module.showData();
                        }
                    }
                });
            }
        }
    });
}

module.detail = function (id) {
    $.ajax({
        url: `/module/update/${id}`,
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            if (response.data.moduleId > 0) {
                $('#DetailModuleModal #bodydetail').empty();
                $('#DetailModuleModal #bodydetail').append(`
                    <ul class="list-group">
                        <li class="list-group-item">Module Name: ${response.data.moduleName}</li>
                        <li class="list-group-item">Duration: ${response.data.duration} week</li>
                        <li class="list-group-item">Status: ${response.data.statusName}</li>                      
                    </ul>
                `);
                $('#DetailModuleModal').modal('show');

            }
        }
    });
}

module.active = function (id) {
    var strmessage = 'You want to switch module over active?';
    module.act(id, 2, strmessage);
}

module.inactive = function (id) {
    var strmessage = 'You want to switch module over inactive?';
    module.act(id, 3, strmessage)
}

module.delete = function (id) {
    var strmessage = 'Do you want to delete module?';
    module.act(id, 4, strmessage)
}


module.init = function () {
    module.showData();
    module.initStatus();
}

$(document).ready(function () {
    module.init();
});