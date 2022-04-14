function CreateDataTable(options) {
    $(document).ready(function () {
        $(options.table.Id).DataTable({
            'processing': true,
            'serverSide': true,
            'filter': false,
            'ajax': {
                'url': options.url,
                'type': 'POST',
                'datatype': 'json',
                'error': function (err) {
                    Notify(err.responseText, 'danger');
                }
            },
            'columns': options.columns
        });
    });
}