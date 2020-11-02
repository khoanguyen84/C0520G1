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
                        <td></td>
                    </tr>`
                );
            });
        }
    });
}

module.openModal = function () {
    $('#addEditModuleModal').modal('show');
}

module.init = function () {
    module.showData();
}

$(document).ready(function () {
    module.init();
});