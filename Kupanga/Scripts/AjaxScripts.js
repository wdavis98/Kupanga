function viewDetails(id) {
    $("#divModalBody").html("Loading...");
    $.ajax({
        url: "/EmployeeAccess/QuoteDetails",
        cache: false,
        type: "POST",
        data: { id: id },
        success: function (html) {
            $("#divModalBody").html(html);
        }
    });
}
function handleQuote(id) {
    $.ajax({
        url: "/EmployeeAccess/HandleQuote",
        cache: false,
        type: "POST",
        data: { id: id },
        success: function (html) {
            window.location.reload();
        }
    });
}