var manufacturerRequest = {
    'table': { 'Id': '#manufacturerTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true,
            //'render': function (data, type, row) {
            //    return "<a class='btn' href='Manufacturer/Get/" + row.id + "'>" + data + "</a>";
            //}
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
                return "<a class='btn btn-info' href='Manufacturer/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'data': {
        'url': 'Manufacturer/GetAll',
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

CreateDataTable(manufacturerRequest);

function DeleteData(Id) {
    var option = {
        'url': 'Manufacturer/Delete',
        'data': { 'id': Id },
        'tableId': '#manufacturerTable'
    }
    Delete(option);
}