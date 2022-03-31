var typeTransportRequest = {
    'table': { 'Id': '#typeTransportTable' },
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

function EditData(Id) {
    $.ajax({
        'url': 'TypeTransport/Edit',
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
        'url': 'TypeTransport/Delete',
        'type': 'POST',
        'data': { 'Id': Id },
        'success': function () {
            $('#typeTransportTable').DataTable().draw();
        }
    })
}