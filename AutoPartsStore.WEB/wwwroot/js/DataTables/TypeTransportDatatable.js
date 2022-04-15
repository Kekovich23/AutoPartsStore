var typeTransportRequest = {
    'table': { 'Id': '#typeTransportTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true,
            'render': function (data, type, row) {
                return "<a class='btn' href='TypeTransport/Get/" + row.id + "'>" + data + "</a>";
            }
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
                return "<a class='btn btn-info' href='/TypeTransport/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'data': {
        'url': 'TypeTransport/GetAll',
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

CreateDataTable(typeTransportRequest);

function DeleteData(Id) {
    var option = {
        'url': 'TypeTransport/Delete',
        'data': { 'id': Id },
        'tableId': '#typeTransportTable'
    }
    Delete(option);
}