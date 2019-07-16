//Bootstrap datepicker plugin
$('#bs_datepicker_component_container').datepicker({
    autoclose: true,
    container: '#bs_datepicker_component_container'
});
$('#bs_datepicker_container').datepicker({
    autoclose: true,
    container: '#bs_datepicker_container'
});
$('#bs_datepicker_range_container').datepicker({
    autoclose: true,
    container: '#bs_datepicker_range_container'
});
$(function () {
    $('.js-basic-example').dataTable({
        responsive: true
    });

    //Exportable table
    $('.js-exportable').dataTable({
        dom: 'Bfrtip',
        responsive: true,
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });
});