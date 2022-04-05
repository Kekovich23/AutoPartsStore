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

function Create(option) {
    $.ajax({
        'url': option.url,
        'type': 'GET',
        'dataType': 'html',
        'success': function (data) {
            $('#ajaxPart').html(data);
            $('#ajaxPart').show();
        },
        'error': function (err) {
            Notify(err.responseText, 'danger');
        }
    })
}

function Edit(option) {
    $.ajax({
        'url': option.url,
        'type': 'GET',
        'dataType': 'html',
        'data': option.data,
        'success': function (data) {
            $('#ajaxPart').html(data);
            $('#ajaxPart').show();
        },
        'error': function (err) {
            Notify(err.responseText, 'danger');
        }
    })
}

function Get(option) {
    $.ajax({
        'url': option.url,
        'type': 'GET',
        'dataType': 'html',
        'data': option.data,
        'success': function (data) {
            $('#ajaxPart').html(data);
            $('#ajaxPart').show();
        },
        'error': function (err) {
            Notify(err.responseText, 'danger');
        }
    })
}