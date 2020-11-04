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
                                <a href="javascripts:;"
                                       onclick="module.detail(${v.moduleId})" class="item"><i class='fas fa-eye'></i></a> 
                                <a href="javascripts:;"
                                       onclick="module.get(${v.moduleId})" class="item"><i class='fas fa-edit text-success'></i></a> 
                                <a href="javascripts:;" class="item"
                                        onclick="module.delete(${v.moduleId})"><i class='fas fa-trash text-danger'></i></a>
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
                bootbox.alert(`<h4 class="text-info font-weight-bold">${response.data.message}</h4>`);
                if (response.data.moduleId > 0) {
                    $('#addEditModuleModal').modal('hide');
                    module.showData();
                }
            }
        });
    }
}

//lấy dữ liệu 1 module sau đó update
module.get = (id) => {
    $.ajax({
        url: `/module/get/${id}`,
        method: 'GET',
        dataType: 'JSON',
        success: (data) => {
            $('#ModuleId').val(data.result.moduleId);
            $('#ModuleName').val(data.result.moduleName);
            $('#Duration').val(data.result.duration);
            $('#Status').val(data.result.status);

            $('.modal-title').text("Update Module").css({ "color": "#8093ad", "padding-left": "0px","font-weight" : "500" });
            $('#addEditModuleModal').modal('show');
        }
    });
}

//xoá 1 module
module.delete = (id) => {
    bootbox.confirm({
        title: "<h4>Delete Module?</h4>",
        message: "<h5 class=\"text-danger font-weight-bold\">Do you want to delete this Module?.</h5>",
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
                    url: `/module/delete/${id}`,
                    method: 'GET',
                    dataType: 'JSON',
                    success: function (data) {
                        console.log(data);
                        bootbox.alert(`<h4 class="text-info font-weight-bold">${data.result.message}</h4>`);
                        module.showData();
                    }
                });
            }
        }
    });
}

//detail 1 module
module.detail = (id) => {
    $.ajax({
        url: `/module/detail/${id}`,
        method: 'GET',
        dataType: 'JSON',
        success: (data) => {
            $('#detail').appendTo('body').modal('show');
            $('#detail-view').empty();
            $('.modal-title').css({ 'padding-left': '100px', 'color': '#65c25d' }).text("Detail Module");
            $('#detail-view').append(
                `
                    <p>Module Id: ${data.result.moduleId}</p>
                    <p>Module Name: ${data.result.moduleName}</p>
                    <p>Duration: ${data.result.duration}</p>
                    <p>Status Name: ${data.result.statusName}</p>
                `
            );
        }
    });
}

//reset form create
module.resetForm = () => {
    $('#ModuleId').val(0);
    $('#ModuleName').val("");
    $('#Duration').val(0);
    $('#Status').val(1);
    $('.modal-title').text('Create Module').css({ "color": "#46c8ad", "padding-left": "0px", "font-weight": "500"});
}

//init
module.init = function () {
    module.showData();
    module.initStatus();
}

$(document).ready(function () {
    module.init();
});