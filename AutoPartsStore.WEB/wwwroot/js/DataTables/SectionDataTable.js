var sectionRequest = {
    'table': { 'Id': '#sectionTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true,
            //'render': function (data, type, row) {
            //    return "<a class='btn' href='Brand/Get/" + row.id + "'>" + data + "</a>";
            //}
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
                return "<a class='btn btn-info' href='Section/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'data': {
        'url': 'Section/GetAll',
        'type': 'POST',
        'datatype': 'json',
        'error': function (err) {
            Notify(err.responseText, 'danger');
        },
        data(d) {
            d.Name = $('#Name').val();
        }
    }
}

CreateDataTable(sectionRequest);

function DeleteData(Id) {
    var option = {
        'url': 'Section/Delete',
        'data': { 'id': Id },
        'tableId': '#sectionTable'
    }
    Delete(option);
}