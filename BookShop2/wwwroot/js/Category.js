var dataTable;

$(document).ready(function () {
    loaddatatable();
});

function loaddatatable() {
    dataTable = $("#tblData").DataTable({
        "ajax": {
            "url": "/Admin/Category/GetAll"
        },
        "columns": [
            { "data": "name", "width": "80%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                        <a href="/Admin/Category/Upsert/${data}" class="btn btn-info">
                            <i class="fa fa-edit"></i>
                        </a>
                        <a class="btn btn-danger" onclick="Delete('/Admin/Category/Delete/${data}')">
                            <i class="fa fa-trash-alt"></i>
                        </a>
                    </div>`;
                },
                "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete this?",
        text: "This action cannot be undone!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
