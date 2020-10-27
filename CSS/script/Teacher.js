var Teacher = Teacher || {};

Teacher.apiUrl = "https://localhost:44393/api/Teacher";

Teacher.drawTable = function() {
    $.ajax({
        url: `${Teacher.apiUrl}/gets`,
        method: 'GET',
        dataType: 'JSON',
        success: function(data) {
            $.each(data, function (i, v) {
                $('#tbTeacher>tbody').append(`
                    <tr>
                        <th>${v.teacherId}</th>
                        <th>${v.fullName}</th>
                        <th>${v.gender}</th>
                        <th>${v.date}</th>
                        <th>${v.email}</th>
                        <th>${v.phoneNumber}</th>
                        <th>${v.level}</th>
                        <th>${v.address}</th>
                        <th>${v.avatar}</th>
                        <th>${v.status}</th>
                        <th>${v.createDate}</th>
                        <th>${v.createBy}</th>
                        <th>${v.dateTimeOffset}</th>
                        <th>${v.modifiedBy}</th>
                    </tr>
                `);
            })
        }
    });
}

Teacher.init = function() {
    Teacher .drawTable();
}


$(document).ready(function() {
    Teacher.init();
});

$(document).ready(function() {
    $("#myBtn").click( function () {
        $("#newCustomerModal").modal("show");
    });
});
$(document).ready(function(){
    $('#save').click(function(){
        var formdata = new FormData();
        formdata.append('FullName', $('#FullName').val());
        formdata.append('Gender', $('#Gender').val());
        formdata.append('Dob', $('#Dob').val());
        formdata.append('Email', $('#Email').val());
        formdata.append('PhoneNumber', $('#PhoneNumber').val());
        formdata.append('Level', $('#Level').val());
        formdata.append('Address', $('#Address').val());
        formdata.append('Avatar', $('#Avatar').val());
        $.ajax({
            type: "POST",
            url: `${Teacher.apiUrl}/CreateTeacher`,
            data: formdata,
            contentType: false, // NEEDED, DON'T OMIT THIS (requires jQuery 1.6+)
            processData: false, 
            success: function () {
                alert("Create Success");
                window.location.href = "http://127.0.0.1:5500/course.html";

            }
        });
    })
});
