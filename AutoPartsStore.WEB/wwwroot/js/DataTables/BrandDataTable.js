var brandRequest = {
    'table': { 'Id': '#brandTable' },
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
                return "<a class='btn btn-info' href='/Brand/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'ajax': {
        'url': 'Brand/GetAll',
        'type': 'POST',
        'datatype': 'json',
        'error': function (err) {
            Notify(err.responseText, null, null, 'danger');
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

function EditData(Id) {
    var option = {
        'url': 'Brand/Edit',
        'data': { 'id': Id }
    }
    Edit(option);
}

function GetData(Id) {
    var option = {
        'url': 'Brand/Get',
        'data': { 'id': Id }
    }
    Get(option);
}

function CreateData() {
    var option = {
        'url': 'Brand/Create'
    }
    Create(option);
}