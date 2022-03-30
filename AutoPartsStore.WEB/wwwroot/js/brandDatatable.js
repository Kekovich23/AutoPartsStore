var brandRequest = {
    'table': { 'Id': '#brandTable' },
    'columns': [
        { 'data' : 'id', 'name' : 'Id', 'autowidth' : true},
        { 'data': 'name', 'name': 'Name', 'autowidth': true },
        {
            "data": null,
            "render": function (data, type, row) {
                return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.id + "'); >Delete</a>";
            }
        },
        {
            "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="Brand/Edit/' + full.Id + '">Edit</a>'; }
        }],
    'ajax': {
        'url': 'Brand/GetBrands',
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
    var request = {
        'table': { 'Id': '#brandTable' },
        'data': { 'Id': Id },
        'url': 'Brand/Delete',
        'type': 'POST'
    }

    $.ajax({
        'url': request.url,
        'type': request.type,
        'data': request.data,
        'success': function () {
            $(request.table.Id).DataTable().draw();
        }
    })
}