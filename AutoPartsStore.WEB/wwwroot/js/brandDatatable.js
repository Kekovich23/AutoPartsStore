var brandRequest = {
    'table': { 'Id': '#brandTable' },
    'columns': [
        { 'data': 'name', 'name': 'Name', 'autowidth': true }],
    'ajax': {
        'url': 'Brand/GetBrands',
        'type': 'POST',
        'datatype': 'json'
    }
}

CreateDataTable(brandRequest);