var course = {} || course;

course.drawTable = function () {

    $.ajax({
        url: `/Employee/Gets/${departId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbEmployee tbody').empty();
            $.each(data.employees, function (i, v) {
                $('#tbEmployee tbody').append(
                    `
                    <tr>
                        <td>${v.employeeId}</td>
                        <td>${v.employeeName}</td>
                        <td>${v.doB}</td>
                        <td>${v.gender}</td>
                        <td><img src='${v.avatarPath}' width='80' height='90'/></td>
                        <td>${v.createdDate}</td>
                        <td>
                            <a href="javascript:;" onclick="employee.get(${v.employeeId})" class="item"><i class="zmdi zmdi-edit"></i></a> 
                            <a href="javascript:;" onclick="employee.delete(${v.employeeId})" class="item"><i class="zmdi zmdi-delete"></i></a>
                        </td>
                    </tr>
                    `
                );
            });
        }
    });

};
course.init = function () {
    course.drawTable();
};

$(document).ready(function () {
    course.init();
});