var student = student || {};

student.detail = (studentId, fullName, gender, dob, email, phoneNumber, statusName, avatar) => {
    $('#detail-view').empty();
    $('#detail-view').append(
        `
            <div class="row">
                <div class="col-5">
                    <img src="/images/${avatar}" alt="your image" style="width: auto; height: 150px;" />
                </div>
                <div class="col-7">
                    <p>Student Id: ${studentId}</p>
                    <p>Full Name: ${fullName}</p>
                    <p>Gender: ${gender}</p>
                    <p>Dob: ${dob}</p>
                    <p>Email: ${email}</p>
                    <p>PhoneNumber: ${phoneNumber}</p>
                    <p>Status Name: ${statusName}</p>
                </div>
            </div>
        `
    );
    $("#detail").appendTo('body').modal("show");

}


student.uploadFile = () => {
    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });

    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#image').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]); // convert to base64 string
        }
    }

    $("#AvatarPath").change(function () {
        readURL(this);
    });
}

$(document).ready(() => {
    student.uploadFile();
})