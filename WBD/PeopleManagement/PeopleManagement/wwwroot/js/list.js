$(document).ready(function () {
    $("#tbPeople").DataTable({
        "columnDefs": [
            { "orderable": false, "targets": 8 }
        ]
    });
});