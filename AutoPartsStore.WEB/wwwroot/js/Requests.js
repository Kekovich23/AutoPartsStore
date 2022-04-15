function Delete(option) {
    if (confirm("Are you sure you want to delete ...?")) {
        $.ajax({
            'url': option.url,
            'type': 'DELETE',
            'data': option.data,
            'success': function () {
                $(option.tableId).DataTable().draw();
            },
            'error': function (err) {
                Notify(err.responseText, 'danger');
            }
        })
    } else {
        return false;
    }
}

function FilterOut(table) {
    $(table).DataTable().draw();
}