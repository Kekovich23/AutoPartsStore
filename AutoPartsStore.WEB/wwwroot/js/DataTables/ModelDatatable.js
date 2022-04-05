var brandRequest = {
    'table': { 'Id': '#modelTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true,
            'render': function (data, type, row) {
                return "<a onclick=GetData('" + row.id + "'); >" + data + "</a>";
            }
        },
        { 'data': 'brand.Name', 'name': 'Brand', 'autowidth': true },
        { 'data': 'typeTransport.Name', 'name': 'Type transport', 'autowidth': true },
        {
            "render": function (data, type, row) {
                return "<a class='btn btn-danger' onclick=DeleteData('" + row.id + "'); >Delete</a>";
            }
        },
        {
            "render": function (data, type, row) {
                return "<a class='btn btn-info' href='/Brand/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'ajax': {
        'url': 'Model/GetModels',
        'type': 'POST',
        'datatype': 'json'
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

function EditData(Id) {
    var option = {
        'url': 'Model/Edit',
        'data': { 'id': Id }
    }
    Edit(option);
}

function GetData(Id) {
    var option = {
        'url': 'Model/Get',
        'data': { 'id': Id }
    }
    Get(option);
}