var register = register || {};

register.changeProvince = function (id) {
    register.drawDistrict(id);
}

register.drawDistrict = function (id) {
    $.ajax({
        url: `/Home/ChangeProvince/${id}`,
        method: "GET",
        dataType: "JSON",
        success: function (data) {
            $('#DistrictId').empty();
            $.each(data.result.districts, function (i, v) {
                $('#DistrictId').append(`
                    <option value='${v.id}'>${v.districtName}</option>
                `);
            });

            $('#WardId').empty();
            $.each(data.result.wards, function (i, v) {
                $('#WardId').append(`
                    <option value='${v.id}'>${v.wardName}</option>
                `);
            });
        }
    });
}

register.changeDistrict = function (id) {
    var provinceId = $("#ProvinceId").val();
    register.drawWard(provinceId, id);
}

register.drawWard = function (provinceId, districId) {
    $.ajax({
        url: `/Home/ChangeDistrict/${provinceId}/${districId}`,
        method: "GET",
        dataType: "JSON",
        success: function (data) {
            $('#WardId').empty();
            $.each(data.wards, function (i, v) {
                $('#WardId').append(`
                    <option value='${v.id}'>${v.wardName}</option>
                `);
            });
        }
    });
}

$(document).ready(function () {

});