var module = {} || module;
module.apiUrl = "https://localhost:44393/api/module";

module.showData = function () {
    $.ajax({
        url: '/module/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbModule>tbody').empty();
            $.each(response.data, function (i, v) {
                var _class = "";
                v.status == 1 ? _class = "btn btn-primary" : (v.status == 2 ? _class = "btn btn-success" : (v.status == 3 ? _class = "btn btn-danger" :"btn btn-warning"));
                var actions = "";
                switch (v.status) {
                    case 2:
                        {
                            actions = `<a href='#' onclick='module.openModal()'><i class='fas fa-edit'></i></a>
                            <a href='#' onclick ='module.complete(${v.moduleId})'><i class='fas fa-check-circle'></i></a>`;
                            break;
                        }
                    case 1:
                        {
                            actions = `<a href='#' onclick ='module.delete(${v.moduleId})'><i class='fas fa-trash'></i></a>
                            <a href='#' onclick='module.openModal()'><i class='fas fa-edit'></i></a>
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
                        <td>${actions}</td>
                    </tr>`
                );
            });
        }
    });
};
module.save = function () {
    var saveObj = {};
    saveObj.ModuleName = $('#ModuleName').val();
    saveObj.Status = parseInt($('#Duration').val());
    saveObj.Duration = parseInt($('#Status').val());
    $.ajax({
        url: `${module.apiUrl}/save`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditModuleModal').append('body').modal('hide');
            alert('Success!');
            module.showData();
        }
    });
}

module.active = function (id) {
    var result = confirm('Bạn muốn bắt đầu module có ID = ' + id)
    if (result) {
        $.ajax({
            url: `${module.apiUrl}/active/${id}`,
            method: "POST",
            dataType: "json",
            success: function () {
                alert('Thành công!');
                window.location.replace("https://localhost:44397/Module/");
            },
        });
    } else {
        alert("Đã hủy")
    };
};
module.editmodal = function (id) {
    $.ajax({
        url: `module/update/${id}`,
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

module.openModal = function () {
    $('#addEditModuleModal').appendTo("body").modal('show');
};

module.init = function () {
    module.showData();
};

$(document).ready(function () {
    module.init();
});