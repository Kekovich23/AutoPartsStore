var brandRequest = {
    'table': { 'Id': '#featureTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true,
            //'render': function (data, type, row) {
            //    return "<a class='btn' href='Model/Get/" + row.id + "'>" + data + "</a>";
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
                return "<a class='btn btn-info' href='/Feature/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'data': {
        'url': 'Feature/GetAll',
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
        'url': 'Feature/Delete',
        'data': { 'id': Id },
        'tableId': '#featureTable'
    }
    Delete(option);
}