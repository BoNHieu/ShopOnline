$(function () {
    $('.js-basic-example').DataTable({
        responsive: true
    });

    //Exportable table
    $('.js-exportable').DataTable({
        dom: 'Bfrtip',
        responsive: true,
        "pageLength":3,
        buttons: [
            'excel', 'pdf', 'print'
        ]
    });
});
