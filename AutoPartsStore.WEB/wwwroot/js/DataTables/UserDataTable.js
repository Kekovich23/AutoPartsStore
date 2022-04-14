var userRequest = {
    'table': { 'Id': '#userTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'userName', 'name': 'Name', 'autowidth': true,
            'render': function (data, type, row) {
                return "<a class='btn' href='User/Get/" + row.id + "'>" + data + "</a>";
            }
        },
        {
            'data': 'email', 'name': 'E-mail', 'autowidth': true
        },
        {
            'data': 'role', 'name': 'Role', 'autowidth': true
        },
        {
            "render": function (data, type, row) {
                return "<a class='btn btn-danger' onclick=DeleteData('" + row.id + "'); >Delete</a>";
            }
        },
        {
            "render": function (data, type, row) {
                return "<a class='btn btn-info' href='User/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'url': 'User/GetAll'
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