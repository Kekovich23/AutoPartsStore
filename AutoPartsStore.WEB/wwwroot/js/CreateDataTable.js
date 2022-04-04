function CreateDataTable(options) {
    $(document).ready(function () {
        $(options.table.Id).DataTable({
            'processing': true,
            'serverSide': true,
            'filter': true,
            'ajax': options.ajax,
            'columns': options.columns
        });
    });
}