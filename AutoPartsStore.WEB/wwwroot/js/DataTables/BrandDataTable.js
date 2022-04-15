var brandRequest = {
    'table': { 'Id': '#brandTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true,
            'render': function (data, type, row) {
                return "<a class='btn' href='Brand/Get/" + row.id + "'>" + data + "</a>";
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
                return "<a class='btn btn-info' href='Brand/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'data': {
        'url': 'Brand/GetAll',
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

CreateDataTable(brandRequest);

function DeleteData(Id) {
    var option = {
        'url': 'Brand/Delete',
        'data': { 'id': Id },
        'tableId': '#brandTable'
    }
    Delete(option);
}