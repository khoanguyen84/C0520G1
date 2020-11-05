var module = {} || module;

module.showData = function () {
    $.ajax({
        url: '/module/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbModule>tbody').empty();
            $.each(response.data, function (i, v) {
                var color = "";
                v.status == 1 ? color = "btn btn-primary" : (v.status == 2 ? color = "btn btn-success" : (v.status == 3 ? color = "btn btn-danger" : "btn btn-warning"));
                var actions = `<a href='javascript:void(0)' onclick='module.detail(${v.moduleId})'><i class='fas fa-info-circle'></i></a> `;
                switch (v.status) {
                    case 2:
                        {
                            actions += `<a href='javascript:void(0)' onclick='module.open(${v.moduleId})'><i class='fas fa-edit'></i></a>
                            <a href='#' onclick ='module.Inactive(${v.moduleId})'><i class='fas fa-check-circle'></i></a>`;
                            break;
                        }
                    case 1:
                        {
                            actions += `<a href='#' onclick ='module.delete(${v.moduleId})'><i class='fas fa-trash'></i></a>
                            <a href='javascript:void(0)' onclick='module.open(${v.moduleId})'><i class='fas fa-edit'></i></a>
                            <a href='#' onclick ='module.active(${v.moduleId})'><i class='far fa-play-circle'></i></a>`;
                            break;
                        }
                }
                $('#tbModule>tbody').append(
                    `<tr>
                        <td>${v.moduleId}</td>
                        <td>${v.moduleName}</td>
                        <td>${v.duration}</td>
                        <td><span class="${color}">${v.statusName}</span></td>
                        <td>${actions}</td>
                    </tr>`
                );
            });
        }
    });
}
module.active = function (id) {
    var strmessage = 'You want to switch module over active?';
    module.act(id, 2, strmessage);
};
module.Inactive = function (id) {
    var strmessage = 'You want to switch module inactive?';
    module.act(id, 3, strmessage);
};
module.delete = function (id) {
    var strmessage = 'Do You want to switch module delete?';
    module.act(id, 4, strmessage);
};
module.act = function (id, status, stringmessage) {
    bootbox.confirm({
        title: '<h1 class = "text-danger">Warning</h1>',
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
                $.ajax({
                    url: `/module/change/${status}/${id}`,
                    method: 'Post',
                    dataType: 'JSON',
                    contentType: 'application/json',
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
};
module.detail = function (id) {
    $.ajax({
        url: `/module/update/${id}`,
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $("#myForm").empty();
            $("#myForm").append(
                `<ul class="list-group container">
                    <div class="row form-group">
                        <label class="col-5">Module name:</label>
                        <li class="list-group-item active">
                            <span>${response.data.moduleName}</span>
                        </li>
                    </div>
                    <div class="row form-group">
                        <label class="col-5">Duration:</label>
                        <li class="list-group-item">
                            <span>${response.data.duration}</span>
                        </li>
                    </div>
                    <div class="row form-group">
                        <label class="col-5">Status:</label>
                        <li class="list-group-item">
                            <span>${response.data.statusName}</span>
                        </li>
                    </div>
                </ul>`);
        }
    });
    $("#newOrderModal").modal("show");
}
module.openModal = function () {
    $('#ModuleId').val(0);
    $('#ModuleName').val('');
    $('#Duration').val('');
    $('#Status').val('');
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
module.open = function (id) {
    $.ajax({
        url: 'module/update/' + id,
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

module.init = function () {
    module.showData();
    module.initStatus();
}

$(document).ready(function () {
    module.init();
});