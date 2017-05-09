$(function() {
    $(".btn-danger").on('click', function() {
        var personId = $(this).data('person-id');
        $.post('/home/delete', { personId: personId }, function() {
            window.location.reload();
        });
    });
});