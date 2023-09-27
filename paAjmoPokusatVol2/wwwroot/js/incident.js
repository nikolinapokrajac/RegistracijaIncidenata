




$(document).ready(function () {
    //populateSelectList1(); // Call function for the first select list
    //populateSelectList2();
    loadDataTable();
    
    document.querySelector('div.toolbar').innerHTML = '<input type="checkbox" id="chkPovrijedjeneOsobe" />Ima povrijeđenih osoba <br/><input type="checkbox" id="chkStradaleOsobe" />Ima stradalih osoba<br/> <label>Incidenti koji su se desilu u periodu od: </label> <input type="text" id="dateFrom"/> <br/> <label>Incidenti koji su se desilu u periodu do: </label> <input type="text" id="dateTo"/>';
    //$('#chkPovrijedjeneOsobe').change(function () {
    //    console.log('Checkbox changed');
    //    var isChecked = $(this).prop('checked');
    //    var brojacCekiranog = 0;
    //    var brojacNecekiranog = 0;
    //    // Iterate through each row in the table
    //    dataTable.rows().every(function () {
    //        console.log("uslo u ifs")
    //        var rowData = this.data();
    //        var columnValue = rowData['injuredPeopleCount']; // Assuming column 3 is index 2

    //        // Toggle row visibility based on the checkbox state and column 3 value
    //        //if (isChecked && columnValue > 0) {
    //        //    brojacCekiranog++;
    //        //    console.log("uslo u drugi if," + columnValue + "," + isChecked + "," + brojacCekiranog)
    //        //    this.nodes().to$().show();
    //        //} else {
    //        //    brojacNecekiranog++;
    //        //    console.log("uslo u else," + columnValue + "," + isChecked + "," + brojacNecekiranog)
    //        //    this.nodes().to$().hide();
    //        //    //dataTable.ajax.reload();
    //        //}
    //        if (isChecked) {
    //            // Your existing code to hide rows based on some condition
    //            if (columnValue > 0) {
    //                this.nodes().to$().show();
    //            } else {
    //                this.nodes().to$().hide();
    //            }
    //        } else {
    //            // Show all rows when the checkbox is unchecked
    //            this.nodes().to$().show();
    //        }

    //    });
    //    brojacCekiranog = 0;
    //    brojacNecekiranog = 0;
    //});
    //$('#chkStradaleOsobe').change(function () {
    //    console.log('Checkbox changed');
    //    var isChecked = $(this).prop('checked');
    //    var brojacCekiranog = 0;
    //    var brojacNecekiranog = 0;
    //    // Iterate through each row in the table
    //    dataTable.rows().every(function () {
    //        console.log("uslo u ifs")
    //        var rowData = this.data();
    //        var columnValue = rowData['deadPeopleCount']; // Assuming column 3 is index 2

    //        // Toggle row visibility based on the checkbox state and column 3 value
    //        //if (isChecked && columnValue > 0) {
    //        //    brojacCekiranog++;
    //        //    console.log("uslo u drugi if," + columnValue + "," + isChecked + "," + brojacCekiranog)
    //        //    this.nodes().to$().show();
    //        //} else {
    //        //    brojacNecekiranog++;
    //        //    console.log("uslo u else," + columnValue + "," + isChecked + "," + brojacNecekiranog)
    //        //    this.nodes().to$().hide();
    //        //    //dataTable.ajax.reload();
    //        //}
    //        if (isChecked) {
    //            // Your existing code to hide rows based on some condition
    //            if (columnValue > 0) {
    //                this.nodes().to$().show();
    //            } else {
    //                this.nodes().to$().hide();
    //            }
    //        } else {
    //            // Show all rows when the checkbox is unchecked
    //            this.nodes().to$().show();
    //        }

    //    });
    //    brojacCekiranog = 0;
    //    brojacNecekiranog = 0;
    //});
    // Handle the first checkbox
    $('#chkPovrijedjeneOsobe').change(function () {
        var isChecked = $(this).prop('checked');
        var chkStradaleOsobe = $('#chkStradaleOsobe').prop('checked');
        // Iterate through each row in the table
        dataTable.rows().every(function () {
            var rowData = this.data();
            var columnValue = rowData['injuredPeopleCount'];
            var columnValue2 = rowData['deadPeopleCount'];
            // Toggle row visibility based on the checkbox state and column value
            if (isChecked && chkStradaleOsobe==false && columnValue > 0) {
                this.nodes().to$().show();
            } else if (isChecked && chkStradaleOsobe && columnValue > 0 && columnValue2>0) {
                this.nodes().to$().show();
            }
        else if (isChecked==false && chkStradaleOsobe && columnValue2 > 0) {
            this.nodes().to$().show();
            }
        else if (!isChecked && !chkStradaleOsobe) {
            this.nodes().to$().show();
        }
            else {
                this.nodes().to$().hide();
            }
        });
    });

    // Handle the second checkbox
    $('#chkStradaleOsobe').change(function () {
        var isChecked = $(this).prop('checked');
        var chkPovrOsobe = $('#chkPovrijedjeneOsobe').prop('checked');
        // Iterate through each row in the table
        dataTable.rows().every(function () {
            var rowData = this.data();
            var columnValue = rowData['deadPeopleCount'];
            var columnValue2 = rowData['injuredPeopleCount'];
            // Toggle row visibility based on the checkbox state and column value
            if (isChecked && chkPovrOsobe == false && columnValue > 0) {
                this.nodes().to$().show();
                //console.log("colona 2");
                //console.log(column[2].footer());
                //console.log("kraj kolone dva");
            } else if (isChecked && chkPovrOsobe && columnValue > 0 && columnValue2 > 0) {
                this.nodes().to$().show();
            }
            else if (isChecked == false && chkPovrOsobe && columnValue2 > 0) {
                this.nodes().to$().show();
            }
            else if (!isChecked && !chkPovrOsobe) {
                this.nodes().to$().show();
            } else {
                this.nodes().to$().hide();
            }
        });
    });





    //$('#dateFrom').change(function () {
    //    var fromDate = $(this);
    //    // Iterate through each row in the table
    //    dataTable.rows().every(function () {
    //        var rowData = this.data();
    //        var columnValue = rowData['dateIncident'];
    //        // Toggle row visibility based on the checkbox state and column value
    //        if (columnValue >= fromDate) {
    //            this.nodes().to$().show();
    //        }
    //        else {
    //            this.nodes().to$().hide();
    //        }
    //    });
    //});
    $('#dateFrom').change(function () {
        //console.log("ude li ovde")
        var fromDateText = $(this).val(); // Get the value from the text field
        var fromDate = new Date(fromDateText); // Convert it to a Date object
        var ToDateText = $('#dateTo').val();
        var toDate = new Date(ToDateText);
        // Check if the input is a valid date
        //if (isNaN(fromDate.getTime())) {
        //    // Handle invalid date input
        //    alert('Please enter a valid date.');
        //    return;
        //}

        // Iterate through each row in the table
        dataTable.rows().every(function () {
            var rowData = this.data();
            var columnValue = new Date(rowData['dateIncident']); // Convert the column value to a Date object

            // Toggle row visibility based on the date range
            if (!(isNaN(fromDate.getTime())) && !(isNaN(toDate.getTime())) && columnValue >= fromDate && columnValue <= toDate) {
                this.nodes().to$().show();
            }
            else if (!(isNaN(fromDate.getTime())) && (isNaN(toDate.getTime())) && columnValue >= fromDate) {
                this.nodes().to$().show();
            }
            else if ((isNaN(fromDate.getTime())) && !(isNaN(toDate.getTime())) && columnValue <= toDate) {
                this.nodes().to$().show();
            }
            else if (isNaN(fromDate.getTime()) && (isNaN(toDate.getTime()))){
                this.nodes().to$().show();
            }
            else {
                this.nodes().to$().hide();
            }
        });

    });

    $('#dateTo').change(function () {
        //console.log("ude li ovde")
        var ToDateText = $(this).val(); // Get the value from the text field
        var toDate = new Date(ToDateText); // Convert it to a Date object
        var fromDateText = $('#dateFrom').val();
        var fromDate = new Date(fromDateText);
        // Check if the input is a valid date
        //if (isNaN(fromDate.getTime())) {
        //    // Handle invalid date input
        //    alert('Please enter a valid date.');
        //    return;
        //}

        // Iterate through each row in the table
        dataTable.rows().every(function () {
            var rowData = this.data();
            var columnValue = new Date(rowData['dateIncident']); // Convert the column value to a Date object

            // Toggle row visibility based on the date range
            if (!(isNaN(fromDate.getTime())) && !(isNaN(toDate.getTime())) && columnValue >= fromDate && columnValue <= toDate) {
                this.nodes().to$().show();
            }
            else if (!(isNaN(fromDate.getTime())) && (isNaN(toDate.getTime())) && columnValue >= fromDate) {
                this.nodes().to$().show();
            }
            else if ((isNaN(fromDate.getTime())) && !(isNaN(toDate.getTime())) && columnValue <= toDate) {
                this.nodes().to$().show();
            }
            else if (isNaN(fromDate.getTime()) && (isNaN(toDate.getTime()))) {
                this.nodes().to$().show();
            }
            else {
                this.nodes().to$().hide();
            }
        });

    });
})





function updateMapWithFilters() {
    // Get the filtered data from the DataTable
    console.log(map);
    var filteredData = dataTable.rows({ search: 'applied' }).data();
    console.log(filteredData);
    // Clear existing markers from the map
    map.eachLayer(function (layer) {
        if (layer instanceof L.Marker) {
            map.removeLayer(layer);
        }
    });

    // Add new markers based on filtered data
    filteredData.each(function (row) {

        var lat = parseFloat(row.incidentLatitude).toFixed(6); // Replace with your data
        var lng = parseFloat(row.incidentLongitude).toFixed(6);
        console.log(lat, lng);
        if (lng > 0 && lat > 0) {
           var marker = L.marker([lat, lng]).addTo(map);
           // var marker = L.marker([43.823811, 18.357902]).addTo(map);
            console.log(row.name);
            // Customize marker and popup as needed
            console.log("ID opstine:"+row.municipalitie.name);
            //marker.bindPopup(row.name + " " + row.id + "<br/><a href='/AboutOneIncident/Index?id=" + row.id + "&name=" + row.name + "&description=" + row.description + " &municipalitieName=" + row.municipalitie.name + "'>link ovdje</a>"); // Replace with your data asp-route-id='row.id' asp-controller='AboutOneIncident' asp-action='Index'
            // &incidentTypeName=" + row.IncidentType.name+"
            var description = row.description.split("'").join("");
            var descriptionFinal = description.split('"').join("");
            console.log(description);
            marker.bindPopup("Naziv incidenta: " + row.name + "<br>Opština u kojoj se desio incident: " + row.municipalitie.name + "<br>Adresa gdje se desio incident: " + row.incidentAddress + "<br>Vrsta incidenta: " + row.incidentType.name + "<br>Datum i vrijeme kad se desio incident: " + row.dateIncident + "<br>Broj povrijeđenih osoba u incidentu: " + row.injuredPeopleCount + "<br>Broj stradalih osoba u incidentu: " + row.deadPeopleCount + "<br/><a href='/AboutOneIncident/Index?id=" + row.id + "&name=" + row.name + "&description=" + descriptionFinal + " &municipalitieName=" + row.municipalitie.name + "&incidentTypeName=" + row.incidentType.name + "&injuredPeopleCount=" + row.injuredPeopleCount + "&deadPeopleCount=" + row.deadPeopleCount + "&dateOfIncident=" + row.dateIncident + "&incidentAddress=" + row.incidentAddress + "'>Opširnije o incidentu</a>"); // Replace with your data asp-route-id='row.id' asp-controller='AboutOneIncident' asp-action='Index'
            //marker.bindPopup("Naziv incidenta: " + row.name + '<a class="btn btn - secondary border form - control" asp-controller="Incident" asp-action="Index">Vrati se na početnu stranu</a>');
            //marker.openPopup(row.name);
        }
        //marker.bindPopup("bilo sta");
    });
}
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
            "dom": '<"toolbar">frtip',
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'description', "width": "25%" },
            { data: 'incidentType.name', "width": "15%" },
            { data: 'municipalitie.name', "width": "15%" },
            { data: 'dateIncident', "width": "15%" },
            { data: 'injuredPeopleCount', "width": "5%" },
            { data: 'deadPeopleCount', "width": "5%" },
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
        initComplete: function SelectList() {
            this.api()
                .columns([2, 3]).every(function () {
                    let column = this;

                    // Create select element
                    let select = document.createElement('select');
                    console.log("OVO JE ZA KOLONU");
                    console.log(column);
                    console.log("SVE");
                    if (column[0] == 2) {
                        select.add(new Option('Svi tipovi incidenata'));
                    }
                    if (column[0] == 3) {
                        select.add(new Option('Sve opštine'));
                    }
                    //select.add(new Option());
                    column.footer().replaceChildren(select);
                    

                    // Apply listener for user change in value
                    select.addEventListener('change', function () {
                        var val = DataTable.util.escapeRegex(select.value);

                        column
                            .search((val === 'Svi tipovi incidenata' || val === 'Sve opštine') ? '' : '^' + val + '$', true, false)
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
    //$('#chkPovrijedjeneOsobe').change(function () {
    //    var isChecked = $(this).prop('checked');

    //    // Iterate through each row in the table
    //    dataTable.rows().every(function () {
    //        var rowData = this.data();
    //        var columnValue = rowData[5]; // Assuming column 3 is index 2

    //        // Toggle row visibility based on the checkbox state and column 3 value
    //        if (isChecked && columnValue > 0) {
    //            this.nodes().to$().show();
    //        } else {
    //            this.nodes().to$().hide();
    //        }
    //    });
    //});
    dataTable.on('draw.dt', function () {
        console.log("usao za mape");
        // Update the map based on the current filters
        updateMapWithFilters();
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