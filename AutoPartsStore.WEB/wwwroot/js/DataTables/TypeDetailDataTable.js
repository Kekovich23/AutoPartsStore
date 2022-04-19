var brandRequest = {
    'table': { 'Id': '#typeDetailTable' },
    'columns': [
        { 'data': 'id', 'name': 'Id', 'autowidth': true },
        {
            'data': 'name', 'name': 'Name', 'autowidth': true,
            //'render': function (data, type, row) {
            //    return "<a class='btn' href='Model/Get/" + row.id + "'>" + data + "</a>";
            //}
        },
        { 'data': 'section.name', 'name': 'Section', 'autowidth': true },
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
                return "<a class='btn btn-info' href='/TypeDetail/Edit/" + row.id + "'>Edit</a>";
            }
        }],
    'data': {
        'url': 'TypeDetail/GetAll',
        'type': 'POST',
        'datatype': 'json',
        'error': function (err) {
            Notify(err.responseText, 'danger');
        },
        data(d) {
            d.Name = $('#Name').val();
            d.SectionId = $('#SectionId').val();
        }
    }
}

CreateDataTable(brandRequest);

function DeleteData(Id) {
    var option = {
        'url': 'TypeDetail/Delete',
        'data': { 'id': Id },
        'tableId': '#typeDetailTable'
    }
    Delete(option);
}