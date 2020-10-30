var Update = Update || {};

Update.apiUrl = "https://localhost:44393/swagger/index.html";

Update.drawTable = function() {
    $.ajax({
        url: `${Update.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function(data) {
            $.each(data, function(i, v) {
                $('#tbCourse>tbody').append(`
                    <tr>
                        <td>${v.ModuleId}</td>
                        <td>${v.ModuleName}</td>
                        <td>${v.Duration}</td>
                        <td>${v.CreatedDate}</td>
                        <td>${v.CreatedBy}</td>
                        <td>${v.ModifiedDate}</td>
                        <td>${v.ModifiedBy}</td>
                        <td></td>
                        
                    </tr>
                `);
            })
        }
    });
}

Update.init = function() {
    Update.drawTable();
}


$(document).ready(function() {
    Update.init();
});