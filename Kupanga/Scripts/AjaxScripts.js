function viewDetails(id) {
    $.ajax({
        url: "/EmployeeAccess/QuoteDetails",
        cache: false,
        type: "POST",
        data: { id: id },
        success: function (html) {
            $("#divModalBody").html(result);
        }
    });
}