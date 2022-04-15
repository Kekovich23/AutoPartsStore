var userRequest = {
    'table': { 'Id': '#userTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'userName', 'name': 'UserName', 'autowidth': true,
            'render': function (data, type, row) {
                return "<a class='btn' href='User/Get/" + row.id + "'>" + data + "</a>";
            }
        },
        {
            'data': 'email', 'name': 'Email', 'autowidth': true
        },
        {
            'data': 'role', 'name': 'Role', 'autowidth': true
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
                return "<a class='btn btn-info' href='User/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'data': {
        'url': 'User/GetAll',
        'type': 'POST',
        'datatype': 'json',
        'error': function (err) {
            Notify(err.responseText, 'danger');
        },
        data(d) {
            d.UserName = $('#UserName').val();
            d.Email = $('#Email').val();
        }
    }
}

CreateDataTable(userRequest);

function DeleteData(Id) {
    var option = {
        'url': 'User/Delete',
        'data': { 'id': Id },
        'tableId': '#userTable'
    }
    Delete(option);
}