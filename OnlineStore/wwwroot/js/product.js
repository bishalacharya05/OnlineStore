﻿let table = new DataTable('#tblData');
var dataTable;
$(document).ready(function () {
    loadDataTable();

});
$('#tblData').DataTable().clear().destroy();
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
            
        },

        "columns": [
            { data: 'title',"width":"15%" },
            { data: 'brand', "width": "15%" },
            { data: 'price', "width": "15%" },
            { data: 'category.categoryName', "width": "15%" },
            {
                data: 'productId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?productId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-squre"></i>Edit</a>
                    <a onClick=Delete('/admin/product/delete?productId=${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                }
            }
        ]
    }); 
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }

            })
        }
    });
}
