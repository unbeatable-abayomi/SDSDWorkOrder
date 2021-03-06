﻿

var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/client/GetAll",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "customerId", "width": "20%" },
       
            {

                "data": "id",
                "render": function (data) {
                    return `
                          <div class="text-center">
                              <a href="/Admin/Client/Upsert/${data}" class="btn btn-primary text-white" style="cursor:pointer; width: 100px;">
                                     <i class="far fa-edit"></i>
                                </a>
                                                &nbsp;
  <a onclick=Delete("/Admin/Client/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
                                     <i class="far fa-trash-alt"></i>
                                </a>
                           </div>
                           `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No records Found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are You Sure You want to Delete?",
        text: "You will not be able to restore the content!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnconfirm: true

    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {

                    ShowMessage(data.message);
                    dataTable.ajax.reload();
                } else {
                    toastr.error(data.message);
                }
            }
        });
    });


}

function ShowMessage(msg) {
    toastr.success(msg);
}