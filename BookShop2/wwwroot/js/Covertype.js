var dataTable
$(document).ready(function () {
    loaddatatable();
});

function loaddatatable() {
    dataTable = $(`#tblData`).dataTable({
        "ajax": {
            "url": "/Admin/Covertype/GetAll"
        },
        "columns": [
            { "data": "name", "width": "80%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                    <a href="/Admin/Covertype/Upsert/${data}" class="btn btn-info">
                    <i class="fas fa-edit"></i>
                    </a>
                    <a class="btn btn-danger" onclick="Delete("/Admin/Covertype/Delete/${data}")">
                    <i class="fas fa-trash-alt"></i>
                    </a>
                    </div>`;
                },
                "width": "20%"
            }
        ]
    });
}
function Delete() {
    swal({
        title: "want to delete data ? ",
        text: "delete information",
        icon: "warning",
        buttons: true,
        dangermode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.massage);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.massage);
                    }
                }
            });
        }
    });

}