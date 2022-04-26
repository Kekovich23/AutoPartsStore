var brandRequest = {
    'table': { 'Id': '#detailTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        { 'data': 'manufacturer.name', 'name': 'Manufacturer', 'autowidth': true },
        { 'data': 'typeDetail.name', 'name': 'TypeDetail', 'autowidth': true },
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
                return "<a class='btn btn-info' href='/Detail/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'data': {
        'url': 'Detail/GetAll',
        'type': 'POST',
        'datatype': 'json',
        'error': function (err) {
            Notify(err.responseText, 'danger');
        },
        data(d) {
            d.Name = $('#Name').val();
            d.ManufacturerId = $('#ManufacturerId').val();
            d.TypeDetailId = $('#TypeDetailId').val();
        }
    }
}

CreateDataTable(brandRequest);

function DeleteData(Id) {
    var option = {
        'url': 'Detail/Delete',
        'data': { 'id': Id },
        'tableId': '#detailTable'
    }
    Delete(option);
}