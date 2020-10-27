var module = module || {};

module.apiUrl = "https://localhost:44393/api/module";

module.drawTable = function () {
    $.ajax({
        url: `${module.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function (data) {
            $.each(data, function (i, v) {
                $('#tbModule>tbody').append(`
                    <tr>
                        <td>${v.moduleId}</td>
                        <td>${v.moduleName}</td>
                        <td>${v.duration}</td>
                    </tr>
                `);
            })
        }
    });
}

module.init = function () {
    module.drawTable();
}


$(document).ready(function () {
    module.init();
});