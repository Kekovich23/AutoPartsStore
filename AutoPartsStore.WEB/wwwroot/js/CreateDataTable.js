function CreateDataTable(request) {
    $(document).ready(function () {
        $(request.table.Id).DataTable({
            'processing': true,
            'serverSide': true,
            'filter': true,
            'ajax': request.ajax,
            'columns': request.columns
        });
    });
}