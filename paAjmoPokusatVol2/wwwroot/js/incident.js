$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    console.log("nina");
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/incident/getall' },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'description', "width": "30%" },
            { data: 'incidentType.name', "width": "25%" },
            { data: 'municipalitie.name', "width": "25%" },
            {
                data: 'id', "render": function (data) {
                    return `<div class="w-55 btn-group" role="group">
                <a href="/incident/upsert?id=${data}" class="btn btn-secondary"><i class="bi bi-pen-fill"></i> Uredi</a>
                <a onClick=Delete('/incident/delete?id=${data}') class="btn btn-secondary"><i class="bi bi-trash3-fill"></i> Obriši</a>
                    </div>`
            }}
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Da li ste sigurni da želite obrisati ovaj incident?',
        text: "Nepovratna akcija!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Da, obriši incident!',
        cancelButtonText: 'Odustani od akcije brisanja'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({ url: url, type: 'DELETE', success: function (data) { dataTable.ajax.reload(); toastr.success(data.message); } })
        }
    })
}