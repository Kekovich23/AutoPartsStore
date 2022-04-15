var brandRequest = {
    'table': { 'Id': '#modelTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true,
            'render': function (data, type, row) {
                return "<a class='btn' href='Model/Get/" + row.id + "'>" + data + "</a>";
            }
        },
        { 'data': 'brand.Name', 'name': 'Brand', 'autowidth': true },
        { 'data': 'typeTransport.Name', 'name': 'TypeTransport', 'autowidth': true },
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
                return "<a class='btn btn-info' href='/Brand/Edit/" + row.id + "'>Edit</a>";
            }
        }],    
     'data': {
         'url': 'Model/GetAll',
        'type': 'POST',
        'datatype': 'json',
        'error': function (err) {
            Notify(err.responseText, 'danger');
        },
        data(d) {
            d.Name = $('#Name').val();
            d.BrandId = $('#BrandId').val();
            d.TypeTransportId = $('#TypeTransportId').val();
        }
    }
}

CreateDataTable(brandRequest);

function DeleteData(Id) {
    var option = {
        'url': 'Model/Delete',
        'data': { 'id': Id },
        'tableId': '#modelTable'
    }
    Delete(option);
}