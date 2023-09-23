




$(document).ready(function () {
    //populateSelectList1(); // Call function for the first select list
    //populateSelectList2();
    loadDataTable();
})

//function populateSelectList1() {
//    // Access the data for the first select list
//    var dataForSelectList1 = @Html.Raw(JsonConvert.SerializeObject(paAjmoPokusat.Models.ViewModels.IncidentVM.IncidentTypeList)); // Replace 'DataForSelectList1' with the actual property name containing the data.
//    var selectElement = document.getElementById('selectList1');

//    dataForSelectList1.forEach(function (item) {
//        var option = document.createElement('option');
//        option.value = item.Id; // Set the value based on your data
//        option.text = item.Name; // Set the text based on your data
//        selectElement.appendChild(option);
//    });
//}

//function populateSelectList2() {
//    // Access the data for the second select list
//    var dataForSelectList2 = @Html.Raw(JsonConvert.SerializeObject(paAjmoPokusat.Models.ViewModels.IncidentVM.MunicipalitieList)); // Replace 'DataForSelectList2' with the actual property name containing the data.
//    var selectElement = document.getElementById('selectList2');

//    dataForSelectList2.forEach(function (item) {
//        var option = document.createElement('option');
//        option.value = item.Id; // Set the value based on your data
//        option.text = item.Name; // Set the text based on your data
//        selectElement.appendChild(option);
//    });
//}
//function loadDataTable() {
//    console.log("nina");
//    dataTable = $('#tblData').DataTable({
//        "ajax": { url: '/incident/getall' },
//        "columns": [
//            { data: 'name', "width": "15%" },
//            { data: 'description', "width": "30%" },
//            { data: 'incidentType.name', "width": "25%" },
//            { data: 'municipalitie.name', "width": "25%" },
//            {
//                data: 'id', "render": function (data) {
//                    return `<div class="w-55 btn-group" role="group">
//                <a href="/incident/upsert?id=${data}" class="btn btn-secondary"><i class="bi bi-pen-fill"></i> Uredi</a>
//                <a onClick=Delete('/incident/delete?id=${data}') class="btn btn-secondary"><i class="bi bi-trash3-fill"></i> Obriši</a>
//                    </div>`
//            }}
//        ]
//    });
//}

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
                }
            }
        ],

        //initComplete: function () {
        //    var api = this.api();

        //    api.columns().every(function () {
        //        let column = this;

        //        // Create select element
        //        let select = document.createElement('select');
        //        select.add(new Option(''));

        //        // Apply listener for user change in value
        //        select.addEventListener('change', function () {
        //            var val = DataTable.util.escapeRegex(select.value);

        //            column
        //                .search(val ? '^' + val + '$' : '', true, false)
        //                .draw();
        //        });

        //        // Fetch data for the select options using AJAX
        //        $.ajax({

        //            url: '/incident/getoptionsincidenttype', // Replace with the URL of your API
        //            dataType: 'json',
        //            success: function (response) {
        //                // Add list of options
        //                console.log(response);
        //                response.forEach(function (optionsIncidentType) {
        //                    select.add(new Option(optionsIncidentType.text, optionsIncidentType.value));
        //                });

        //                // Add the select element to the footer
        //                //column.footer().replaceChildren(select);
        ////                var footerCell = $(column.footer());

        ////// Empty the footer cell and append the select element
        //                //footerCell.empty().append(select);
        //                //column.footer().add(select);
        //                column.replaceChildren(select);
        //            }
        //        });

        //    });
        //}
        //    });
        initComplete: function () {
            this.api()
                .columns([2,3]).every(function () {
                    let column = this;

                    // Create select element
                    let select = document.createElement('select');
                    select.add(new Option(''));
                    column.footer().replaceChildren(select);

                    // Apply listener for user change in value
                    select.addEventListener('change', function () {
                        var val = DataTable.util.escapeRegex(select.value);

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                    // Add list of options
                    column
                        .data()
                        .unique()
                        .sort()
                        .each(function (d, j) {
                            select.add(new Option(d));
                        });
            });

        }
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