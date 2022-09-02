const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));

$(document).ready(function () {

    $.validator.addMethod('noSpace', function (value, element) {
        return value == '' || value.trim().length != 0

    }, "Space are not Allowed");

    $('#formEdit').validate({
        rules: {
            Name: {
                required: true,
                noSpace: true
            },
            DateOfBirth: {
                required: true
            },
            Address: {
                required: true,
                noSpace: true
            }
        }
    }, false);

    $('#formCreate').validate({
        rules: {
            Name: {
                required: true,
                noSpace: true
            },
            DateOfBirth: {
                required: true
            },
             Address: {
                required: true,
                noSpace: true
            }
        }
    }, false);
});
function changeImage(value) {

    var FileID = $(value).next().attr("id");
    const input = document.getElementById(FileID);
    input.click();

    input.onchange = e => {
        var file = e.target.files[0];
        if (file.type.includes("image") == true) {
            value.src = URL.createObjectURL(file);
        }
        else
            alert("Error In File !");
    }
}
function clickSearch(value) {
    if ($(value).val() != "") {
        $(".navbar-brand , .ShowUser header , .navbar-toggler .fa").hide(700);

        var url = "/Home/Search";
        $.ajax({
            url: url,
            dataType: 'json',
            data: { value: $(value).val() },
            success: function (data) {
                var Result = '';
                $('.ShowUser .row .col').remove();


                if (data == null) {
                    $("#ErrorNotFound").removeClass('d-none');
                    $(".ShowUser").hide();
                }
                else {
                    $.each(data, function (i, item) {
                        Result += `<div class="col">
                        <a class="card" id="card"  onclick="EditEmployee(`+ item.id + `)"
                            data-bs-toggle="modal" data-bs-target="#EditProfile">
                            <div class="card-body">
                                <div class="user-picture">`;

                               if (item.files!="") {
                                   Result += `<img src="data:image/;base64,` + item.file.image + `" class="shadow-sm rounded-circle" />`;
                               }
                               else {
                                   Result += `<img src="/Images/UserImage.png" class="shadow-sm rounded-circle" />`;
                               }
                                     
                            Result +=  `</div>
                                <div class="user-content">
                                    <h5 class="text-capitalize user-name">`+ item.name + `</h5>
                                    <p class=" text-capitalize text-muted blockquote-footer">`+ item.departments.deptName + `</p>
                                    <p class="small text-muted mb-0">`+ item.address + `</p>
                                </div>
                            </div>
                        </a>
                    </div>`;
                });
                $('.ShowUser .row').html(Result);
                }
            }
        });
    }
    else {
        $(".navbar-brand , .ShowUser header, .navbar-toggler .fa").show(700);
         window.location.href = '/';
    }
}
function EditEmployee(ID) {
    var url = "/Home/GetEmployee";
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'GET',
        data: { ID: ID },
        success: function (item) {
            $("#EditProfile #DeleteUser").attr("href", "/Home/Delete/" + item.id);
            if (item.files != "")

                $("#EditProfile #imgUser").attr("src", "data:image/;base64," + item.file.image);
            else
                $("#EditProfile #imgUser").attr("src","/Images/UserImage.png" );

            $("#EditProfile #IdUser").val(item.id);
            $("#EditProfile #UserName").val(item.name);
            $("#EditProfile #BirthDay")
                .val(new Date(item.dateOfBirth).toJSON().slice(0, 10));
            $("#EditProfile #DeptName").val(item.departmentID);
            $("#EditProfile #address").val(item.address);
        }
    });
}

