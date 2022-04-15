function CreateDataTable(options) {
    $(document).ready(function () {
        $(options.table.Id).DataTable({
            'processing': true,
            'serverSide': true,
            'filter': false,
            'ajax': options.data,
            'columns': options.columns
        });
    });
}