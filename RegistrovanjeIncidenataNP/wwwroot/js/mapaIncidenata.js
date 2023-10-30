
var datatable;
$(document).ready(function () {
    console.log("mapa incidenata");
    dataTable = $('#tblData2').DataTable({

        "ajax": { url: '/incident/getallincidentsformap' },
        "dom": '<"toolbar">frtip',
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'description', "width": "25%" },
            { data: 'incidentType.name', "width": "15%" },
            { data: 'municipalitie.name', "width": "15%" },
            { data: 'dateIncident', "width": "15%" },
            { data: 'injuredPeopleCount', "width": "5%" },
            { data: 'deadPeopleCount', "width": "5%" },
            { data: 'incidentImages', "width": "5%" },
            {
                data: 'id', "render": function (data) {
                    return `<div class="w-55 btn-group" role="group">
                        <a href="/incident/upsert?id=${data}" class="btn btn-secondary"><i class="bi bi-pen-fill"></i> Uredi</a>
                        <a onClick=Delete('/incident/delete?id=${data}') class="btn btn-secondary"><i class="bi bi-trash3-fill"></i> Obriši</a>
                    </div>`
                }
            }
        ],
 
        paging: false,
        "responsive": true,
        initComplete: function () {

            var filterContainer = document.querySelector('#filterDiv');


            
            this.api().columns([4]).every(function () {
                let column = this;
                let date = document.querySelector("#dateFrom");
                let dateTo = document.querySelector("#dateTo");
                date.addEventListener('change', function () {
                    
                        console.log(date.value);
                    if (!date.value) {
                        date.value = "0001-01-01";
                        date.dispatchEvent(new Event('change'));
                    }
                    else {
                        let regexPattern = '^(?:(?!' + date.value + ').)*$'
                        column.search(regexPattern, true, false).draw();
                    }
                    
                    
                    
                });

                dateTo.addEventListener('change', function () {
                    console.log(date.value);
                    if (!dateTo.value) {
                        dateTo.value = "9999-12-31";
                        dateTo.dispatchEvent(new Event('change'));
                    }
                    else {
                        let regexPattern = '^(?:(?!' + dateTo.value + ').)*$'
                        column.search(regexPattern, true, false).draw();
                    }
                    
                });

            });

            this.api().columns([6]).every(function () {
                let column = this;
                let checkbox = document.querySelector("#chkStradaleOsobe");


                checkbox.addEventListener('change', function () {
                    let val = checkbox.checked;
                    column.search(val ? '[^0]' : '', true, false).draw();
                });
            });

            this.api().columns([5]).every(function () {
                let column = this;
                let checkbox = document.querySelector("#chkPovrijedjeneOsobe");

                checkbox.addEventListener('change', function () {
                    let val = checkbox.checked;
                    console.log(val);
                    column.search(val ? '[^0]' : '', true, false).draw();
                    console.log('UUUUUAAAAA');
                });
            });

            this.api().columns([2, 3]).every(function () {
                let column = this;
                let select = document.createElement('select');
                let label = document.createElement('label'); 
                let div = document.createElement('div'); 

                if (column[0] == 2) {
                    select.add(new Option('Svi tipovi incidenata'));
                    label.textContent = 'Tip incidenta:  '; 
                }
                if (column[0] == 3) {
                    select.add(new Option('Sve opštine'));
                    label.textContent = 'Opština:  '; 
                }

          
                div.appendChild(label);

                div.appendChild(select);
                div.style = "display:flex; flex-direction:row;justify-content:space-between;";
                select.style = "width:11em";

                filterContainer.appendChild(div);

   
                select.addEventListener('change', function () {
                    var val = DataTable.util.escapeRegex(select.value);
                    console.log("Vrijednost: " + val);
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
    document.querySelector('div.toolbar').innerHTML = '<div id="filterDiv" style="position:fixed;top:270px;right:20px;"><input type="checkbox" id="chkPovrijedjeneOsobe" />Ima povrijeđenih osoba <br/><input type="checkbox" id="chkStradaleOsobe" />Ima stradalih osoba<br/> <label>Incidenti u periodu od: </label> <input type="date" style="width:11em" id="dateFrom"/> <br/> <label>Incidenti u periodu do: </label> <input type="date" style="width:11em" id="dateTo"/></br></div>';
    document.querySelector('#tblData2_filter').style = "display:none";
    document.querySelector('#tblData2_info').style = "display:none";
    //$('#chkPovrijedjeneOsobe').change(function () {
    //    var isChecked = $(this).prop('checked');
    //    var chkStradaleOsobe = $('#chkStradaleOsobe').prop('checked');
    //    dataTable.rows().every(function () {
    //        var rowData = this.data();
    //        var columnValue = rowData['injuredPeopleCount'];
    //        var columnValue2 = rowData['deadPeopleCount'];
    //        if (isChecked && chkStradaleOsobe == false && columnValue > 0) {
    //            this.nodes().to$().show();
    //        } else if (isChecked && chkStradaleOsobe && columnValue > 0 && columnValue2 > 0) {
    //            this.nodes().to$().show();
    //        }
    //        else if (isChecked == false && chkStradaleOsobe && columnValue2 > 0) {
    //            this.nodes().to$().show();
    //        }
    //        else if (!isChecked && !chkStradaleOsobe) {
    //            this.nodes().to$().show();
    //        }
    //        else {
    //            this.nodes().to$().hide();
    //        }
    //    });



    //        updateMapWithFilters();

    //    //datatable.draw();
    //});


    //$('#chkStradaleOsobe').change(function () {
    //    var isChecked = $(this).prop('checked');
    //    var chkPovrOsobe = $('#chkPovrijedjeneOsobe').prop('checked');

    //    dataTable.rows().every(function () {
    //        var rowData = this.data();
    //        var columnValue = rowData['deadPeopleCount'];
    //        var columnValue2 = rowData['injuredPeopleCount'];
    //        if (isChecked && chkPovrOsobe == false && columnValue > 0) {
    //            this.nodes().to$().show();
    //            //updateMapWithFilters();
    //        } else if (isChecked && chkPovrOsobe && columnValue > 0 && columnValue2 > 0) {
    //            this.nodes().to$().show();
    //            //updateMapWithFilters();
    //        }
    //        else if (isChecked == false && chkPovrOsobe && columnValue2 > 0) {
    //            this.nodes().to$().show();
    //            //updateMapWithFilters();
    //        }
    //        else if (!isChecked && !chkPovrOsobe) {
    //            this.nodes().to$().show();
    //            //updateMapWithFilters();
    //        } else {
    //            this.nodes().to$().hide();
    //            //updateMapWithFilters();
    //        }
    //    });
    //});

    //$('#dateFrom').change(function () {

    //    var fromDateText = $(this).val();
    //    var fromDate = new Date(fromDateText);
    //    var ToDateText = $('#dateTo').val();
    //    var toDate = new Date(ToDateText);

    //    dataTable.rows().every(function () {
    //        var rowData = this.data();
    //        var columnValue = new Date(rowData['dateIncident']);


    //        if (!(isNaN(fromDate.getTime())) && !(isNaN(toDate.getTime())) && columnValue >= fromDate && columnValue <= toDate) {
    //            this.nodes().to$().show();
    //        }
    //        else if (!(isNaN(fromDate.getTime())) && (isNaN(toDate.getTime())) && columnValue >= fromDate) {
    //            this.nodes().to$().show();
    //        }
    //        else if ((isNaN(fromDate.getTime())) && !(isNaN(toDate.getTime())) && columnValue <= toDate) {
    //            this.nodes().to$().show();
    //        }
    //        else if (isNaN(fromDate.getTime()) && (isNaN(toDate.getTime()))) {
    //            this.nodes().to$().show();
    //        }
    //        else {
    //            this.nodes().to$().hide();
    //        }
    //    });

    //});

    //$('#dateTo').change(function () {

    //    var ToDateText = $(this).val();
    //    var toDate = new Date(ToDateText);
    //    var fromDateText = $('#dateFrom').val();
    //    var fromDate = new Date(fromDateText);

    //    dataTable.rows().every(function () {
    //        var rowData = this.data();
    //        var columnValue = new Date(rowData['dateIncident']);

    //        if (!(isNaN(fromDate.getTime())) && !(isNaN(toDate.getTime())) && columnValue >= fromDate && columnValue <= toDate) {
    //            this.nodes().to$().show();
    //        }
    //        else if (!(isNaN(fromDate.getTime())) && (isNaN(toDate.getTime())) && columnValue >= fromDate) {
    //            this.nodes().to$().show();
    //        }
    //        else if ((isNaN(fromDate.getTime())) && !(isNaN(toDate.getTime())) && columnValue <= toDate) {
    //            this.nodes().to$().show();
    //        }
    //        else if (isNaN(fromDate.getTime()) && (isNaN(toDate.getTime()))) {
    //            this.nodes().to$().show();
    //        }
    //        else {
    //            this.nodes().to$().hide();
    //        }
    //    });

    //});

    dataTable.on('draw.dt', function () {


        updateMapWithFilters();
    });
    $('#dateFrom').on('change', function () {
        var specifiedDate = new Date($('#dateFrom').val());

        $.fn.dataTable.ext.search.pop(); // Remove any previous custom search

        if (specifiedDate) {
            $.fn.dataTable.ext.search.push(function (settings, data, dataIndex) {
                var dateValue = new Date(data[4]);
                if (!specifiedDate) return true;
                return dateValue > specifiedDate;
            });

            table.draw();
        }
    });

    $('#dateTo').on('change', function () {
        var specifiedDate = new Date($('#dateTo').val());

        $.fn.dataTable.ext.search.pop(); // Remove any previous custom search

        if (specifiedDate) {
            $.fn.dataTable.ext.search.push(function (settings, data, dataIndex) {
                var dateValue = new Date(data[4]);
                if (!specifiedDate) return true;
                return dateValue < specifiedDate;
            });

            table.draw();
        }
    });
});

function updateMapWithFilters() {

    var filteredData = dataTable.rows({ search: 'applied' }).data();
    var deadPeople = $("#chkStradaleOsobe").prop('checked');
    var injuredPeople = $("#chkPovrijedjeneOsobe").prop('checked');

    map.eachLayer(function (layer) {
        if (layer instanceof L.Marker) {
            map.removeLayer(layer);
        }
    });


    filteredData.each(function (row) {

        var lat = parseFloat(row.incidentLatitude).toFixed(6);
        var lng = parseFloat(row.incidentLongitude).toFixed(6);
        console.log("uslo u filteredData")

        if (lng > 0 && lat > 0) {
            var marker = L.marker([lat, lng]).addTo(map);

            var description = row.description.split("'").join("");
            var descriptionFinal = description.split('"').join("");

           
            var date = new Date(row.dateIncident);
            var formattedDate = ("0" + date.getDate()).slice(-2) + "/" + ("0" + (date.getMonth() + 1)).slice(-2) + "/" + date.getFullYear();
            marker.bindPopup("Naziv incidenta: " + row.name + "<br>Opština u kojoj se desio incident: " + row.municipalitie.name + "<br>Adresa gdje se desio incident: " + row.incidentAddress + "<br>Vrsta incidenta: " + row.incidentType.name + "<br>Datum kad se desio incident: " + formattedDate + "<br>Broj povrijeđenih osoba u incidentu: " + row.injuredPeopleCount + "<br>Broj stradalih osoba u incidentu: " + row.deadPeopleCount + "<br/><br/><a href='/AboutOneIncident/Index/" + row.id + "'>Opširnije o incidentu</a>"); // Replace with your data asp-route-id='row.id' asp-controller='AboutOneIncident' asp-action='Index'
        }

    });
}
