var brandRequest = {
    'table': { 'Id': '#brandTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        { 'data': 'name', 'name': 'Name', 'autowidth': true },
        {
            "data": null,
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
        'url': 'Brand/Get',
        'type': 'POST',
        'datatype': 'json'
    }
}

CreateDataTable(brandRequest);

function EditData(Id) {
    $.ajax({
        'url': 'Brand/Edit',
        'type': 'GET',
        'dataType': 'html',
        'data': { 'Id': Id },
        'success': function (data) {
            $('#ajaxPart').html(data);
            $('#ajaxPart').show();
        }
    })
}

function DeleteData(Id) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(Id);
    } else {
        return false;
    }
}

function Delete(Id) {
    $.ajax({
        'url': 'Brand/Delete',
        'type': 'POST',
        'data': { 'Id': Id },
        'success': function () {
            $('#brandTable').DataTable().draw();
        }
    })
}