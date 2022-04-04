var brandRequest = {
    'table': { 'Id': '#modelTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        { 'data': 'name', 'name': 'Name', 'autowidth': true },
        { 'data': 'brand.Name', 'name': 'Brand', 'autowidth': true },
        { 'data': 'typeTransport.Name', 'name': 'Type transport', 'autowidth': true },
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
        'url': 'Model/GetModels',
        'type': 'POST',
        'datatype': 'json'
    }
}

CreateDataTable(brandRequest);

function DeleteData(Id) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(Id);
    } else {
        return false;
    }
}

function Delete(Id) {
    $.ajax({
        'url': 'Model/Delete',
        'type': 'POST',
        'data': { 'Id': Id },
        'success': function () {
            $('#modelTable').DataTable().draw();
        }
    })
}