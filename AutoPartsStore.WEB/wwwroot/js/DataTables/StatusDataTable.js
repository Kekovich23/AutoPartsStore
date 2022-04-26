var statusRequest = {
    'table': { 'Id': '#statusTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true            
        },
        {
            'orderable': false,
            'searchable': false,
            "render": function (data, type, row) {
                return "<a class='btn btn-danger' onclick=DeleteData('" + row.id + "'); >Delete</a>";
            }
        },
        {
            'orderable': false,
            'searchable': false,
            "render": function (data, type, row) {
                return "<a class='btn btn-info' href='/Status/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'data': {
        'url': 'Status/GetAll',
        'type': 'POST',
        'datatype': 'json',
        'error': function (err) {
            Notify(err.responseText, 'danger');
        },
        data(d) {
            d.Name = $('#Name').val();
        }
    }
}

CreateDataTable(statusRequest);

function DeleteData(Id) {
    var option = {
        'url': 'Status/Delete',
        'data': { 'id': Id },
        'tableId': '#statusTable'
    }
    Delete(option);
}