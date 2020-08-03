var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/workorder/workorder/GetAll",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "details", "width": "20%" },
            { "data": "description", "width": "30%" },
            { "data": "product.name", "width": "20%" },
            { "data": "client.name", "width": "20%" },
            {
        
                "data": "id",
                "render": function (data) {
                    return `
                          <div class="text-center">
                              <a href="/workorder/workorder/addworkorder/${data}" class="btn btn-primary text-white" style="cursor:pointer; width: 50px;">
                                     <i class="far fa-edit"></i>
                                </a>
                                                &nbsp;
  <a onclick=Delete("/workorder/workorder/delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width: 50px;">
                                     <i class="far fa-trash-alt"></i>
                                </a>
                               &nbsp;
  <div class="text-center">
                              <a href="/workorder/workorder/details/${data}" class="btn btn-primary text-white" style="cursor:pointer; width: 50px;">
                                     <i class="fas fa-binoculars"></i>
                                </a>
                           `;
                }, "width": "20%"
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