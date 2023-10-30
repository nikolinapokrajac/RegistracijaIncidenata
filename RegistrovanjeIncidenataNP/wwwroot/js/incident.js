




$(document).ready(function () {
   
    
    loadDataTable();
    var filtersDiv = document.querySelector("#divSaFilterima");
    filtersDiv.innerHTML = '<div id="filterDiv" style="position:sticky;top:270px;right:20px;padding:10px;"><input type="checkbox" id="chkPovrijedjeneOsobe" />Ima povrijeđenih osoba <br/><input type="checkbox" id="chkStradaleOsobe" />Ima stradalih osoba<br/> <label>Incidenti u periodu od: </label> <input type="date" style="width:11em" id="dateFrom"/> <br/> <label>Incidenti u periodu do: </label> <input type="date" style="width:11em" id="dateTo"/></br></div>';
   
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








function loadDataTable() {
    console.log("nina");
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/incident/getall' },
        "dom": '<"toolbar">frtip',
        "columns": [
                        { data: 'name', "width": "15%" },
            //{ data: 'description', "width": "25%" },
            { data: 'incidentType.name', "width": "15%" },
            { data: 'municipalitie.name', "width": "15%" },
            { data: 'dateIncident', "width": "25%" },
            { data: 'injuredPeopleCount', "width": "5%" },
            { data: 'deadPeopleCount', "width": "5%" },
            {
                data: 'id', "render": function (data) {
                    return `<div class="w-55 btn-group" role="group">
                        <a href="/incident/upsert?id=${data}" class="btn btn-secondary"><i class="bi bi-pen-fill"></i> Uredi</a></br>
                        <a href="/aboutoneincident/index?id=${data}" class="btn btn-secondary"><i class="bi bi-info-square-fill"></i> Detaljno</a></br>
                        <a onClick=Delete('/incident/delete?id=${data}') class="btn btn-secondary"><i class="bi bi-trash3-fill"></i> Obriši</a>

                    </div>`
                }
            }
        ],
        "columnDefs": [
            {
                "targets": 3,    
                "render": function (data, type, row) {
                    var dateFromDb = new Date(data);
                    var formattedDate = ("0" + dateFromDb.getDate()).slice(-2) + "/" + ("0" + (dateFromDb.getMonth() + 1)).slice(-2) + "/" + dateFromDb.getFullYear();
                    return formattedDate;
                },
            },
            
        ],
        "responsive": true,
        paging: true,

        initComplete: function () {

            var filterContainer = document.querySelector('#filterDiv');
            console.log(filterContainer);

        
            this.api().columns([1, 2]).every(function () {
                let column = this;
                let select = document.createElement('select');
                let label = document.createElement('label'); 
                let div = document.createElement('div'); 

                if (column[0] == 1) {
                    select.add(new Option('Svi tipovi'));
                    label.textContent = 'Tip incidenta:  ';
                }
                if (column[0] == 2) {
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

                    console.log("Vrijednost: "+val);
                    column

                        .search((val === 'Svi tipovi' || val === 'Sve opštine') ? '' : '^' + val + '$', true, false)
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