




$(document).ready(function () {
    
    loadDataTable();
    
    document.querySelector('div.toolbar').innerHTML = '<input type="checkbox" id="chkPovrijedjeneOsobe" />Ima povrijeđenih osoba <br/><input type="checkbox" id="chkStradaleOsobe" />Ima stradalih osoba<br/> <label>Incidenti koji su se desilu u periodu od: </label> <input type="text" id="dateFrom"/> <br/> <label>Incidenti koji su se desilu u periodu do: </label> <input type="text" id="dateTo"/>';
   
    $('#chkPovrijedjeneOsobe').change(function () {
        var isChecked = $(this).prop('checked');
        var chkStradaleOsobe = $('#chkStradaleOsobe').prop('checked');
        dataTable.rows().every(function () {
            var rowData = this.data();
            var columnValue = rowData['injuredPeopleCount'];
            var columnValue2 = rowData['deadPeopleCount'];
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


    $('#chkStradaleOsobe').change(function () {
        var isChecked = $(this).prop('checked');
        var chkPovrOsobe = $('#chkPovrijedjeneOsobe').prop('checked');

        dataTable.rows().every(function () {
            var rowData = this.data();
            var columnValue = rowData['deadPeopleCount'];
            var columnValue2 = rowData['injuredPeopleCount'];
            if (isChecked && chkPovrOsobe == false && columnValue > 0) {
                this.nodes().to$().show();
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

    $('#dateFrom').change(function () {

        var fromDateText = $(this).val(); 
        var fromDate = new Date(fromDateText); 
        var ToDateText = $('#dateTo').val();
        var toDate = new Date(ToDateText);

        dataTable.rows().every(function () {
            var rowData = this.data();
            var columnValue = new Date(rowData['dateIncident']); 


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

        var ToDateText = $(this).val(); 
        var toDate = new Date(ToDateText); 
        var fromDateText = $('#dateFrom').val();
        var fromDate = new Date(fromDateText);

        dataTable.rows().every(function () {
            var rowData = this.data();
            var columnValue = new Date(rowData['dateIncident']); 

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

    console.log(map);
    var filteredData = dataTable.rows({ search: 'applied' }).data();
    console.log(filteredData);

    map.eachLayer(function (layer) {
        if (layer instanceof L.Marker) {
            map.removeLayer(layer);
        }
    });


    filteredData.each(function (row) {

        var lat = parseFloat(row.incidentLatitude).toFixed(6); 
        var lng = parseFloat(row.incidentLongitude).toFixed(6);
        console.log(lat, lng);
        if (lng > 0 && lat > 0) {
           var marker = L.marker([lat, lng]).addTo(map);
            
            var description = row.description.split("'").join("");
            var descriptionFinal = description.split('"').join("");
            console.log(description);
            marker.bindPopup("Naziv incidenta: " + row.name + "<br>Opština u kojoj se desio incident: " + row.municipalitie.name + "<br>Adresa gdje se desio incident: " + row.incidentAddress + "<br>Vrsta incidenta: " + row.incidentType.name + "<br>Datum i vrijeme kad se desio incident: " + row.dateIncident + "<br>Broj povrijeđenih osoba u incidentu: " + row.injuredPeopleCount + "<br>Broj stradalih osoba u incidentu: " + row.deadPeopleCount + "<br/><a href='/AboutOneIncident/Index?id=" + row.id + "&name=" + row.name + "&description=" + descriptionFinal + " &municipalitieName=" + row.municipalitie.name + "&incidentTypeName=" + row.incidentType.name + "&injuredPeopleCount=" + row.injuredPeopleCount + "&deadPeopleCount=" + row.deadPeopleCount + "&dateOfIncident=" + row.dateIncident + "&incidentAddress=" + row.incidentAddress + "'>Opširnije o incidentu</a>"); // Replace with your data asp-route-id='row.id' asp-controller='AboutOneIncident' asp-action='Index'
            
        }

    });
}


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



     
        initComplete: function SelectList() {
            this.api()
                .columns([2, 3]).every(function () {
                    let column = this;


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

                    column.footer().replaceChildren(select);
                    


                    select.addEventListener('change', function () {
                        var val = DataTable.util.escapeRegex(select.value);

                        column
                            .search((val === 'Svi tipovi incidenata' || val === 'Sve opštine') ? '' : '^' + val + '$', true, false)
                            .draw();
                    });

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


  
    dataTable.on('draw.dt', function () {
        console.log("usao za mape");
       
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