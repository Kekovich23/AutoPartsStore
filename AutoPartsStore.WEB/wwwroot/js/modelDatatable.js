var brandRequest = {
    'table': { 'Id': '#modelTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        { 'data': 'name', 'name': 'Name', 'autowidth': true },
        { 'data': 'typeTransport', 'name': 'TypeTransport.Name', 'autowidth': true },
        { 'data': 'brand', 'name': 'Brand.Name', 'autowidth': true },
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

function EditData(Id) {
    $.ajax({
        'url': 'Brand/Edit',
        'type': 'GET',
        'dataType': 'html',
        'data': { 'Id': Id },
        'success': function () {
            $('#ajaxPart').html(Id);
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