var typeTransportRequest = {
    'table': { 'Id': '#typeTransportTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true,
            'render': function (data, type, row) {
                return "<a onclick=GetData('" + row.id + "'); >" + data + "</a>";
            }
        },
        {
            "render": function (data, type, row) {
                return "<a class='btn btn-danger' onclick=DeleteData('" + row.id + "'); >Delete</a>";
            }
        },
        {
            "render": function (data, type, row) {
                return "<a class='btn btn-info' href='/TypeTransport/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'ajax': {
        'url': 'TypeTransport/GetTypeTransports',
        'type': 'POST',
        'datatype': 'json'
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

function EditData(Id) {
    var option = {
        'url': 'TypeTransport/Edit',
        'data': { 'id': Id }
    }
    Edit(option);
}

function GetData(Id) {
    var option = {
        'url': 'TypeTransport/Get',
        'data': { 'id': Id }
    }
    Get(option);
}