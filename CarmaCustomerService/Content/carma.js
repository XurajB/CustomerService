function ShowProgress() {
    setTimeout(function () {
        var modal = $('<div />');
        modal.addClass("modal");
        $('body').append(modal);
        var loading = $(".loading");
        loading.show();
        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
    }, 200);
}
var confirmed = false;
function confirmDialog(obj) {
    if (!confirmed) {
         $("#dialog-confirm").dialog({
             resizable: false,
             height: 140,
             modal: true,
             buttons: {
                 "Yes": function ()
                 {
                     $(this).dialog("close");
                     confirmed = true; obj.click();
                 },
                 "No": function ()
                 {
                      $(this).dialog("close");
                 }
            }
         });
    } return confirmed;
}