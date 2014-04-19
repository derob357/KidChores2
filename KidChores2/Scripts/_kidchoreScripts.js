//edit Room
$(".edit-room").live("click", function (e) {
    e.preventDefault();
    showLoader('Editing room');
    var noteId = $(this).attr("id").replace('edit-', '');
    var liId = '#bar-' + roomId;
    //load note from db and open in dialog
    $.ajax({
        type: "GET",
        url: "/Room/EditRoom",
        data: { id: RoomId },
        cache: false,
        dataType: "json",
        success: function (mymodel) {
            $('#myModal').modal();
            $("#edit-popup").html(mymodel.Html);
            $("#edit-popup").dialog({
                resizable: true,
                height: 210,
                width: 510,
                modal: true,
                buttons: {
                    Save: function () {
                        var boxval = $("#edit-content").val();
                        if (!boxval) {
                            showError("Can't save an empty model");
                            return;
                        }
                        $.ajax({
                            type: "POST",
                            url: "/Room/EditRoom",
                            data: { id: RoomId, content: boxval },
                            cache: false,
                            dataType: "json",
                            success: function (data) {
                                if (data.Message) {
                                    showError(data.Message);
                                } else {
                                    //$(liId).replaceWith(data.Html);
                                    //$(liId).slideDown("slow");
                                    $("#flash").hide();
                                    $("#edit-popup").dialog("close");
                                }
                            }
                        }); //end save call
                    }, // end ok button
                    Cancel: function () {
                        $("#flash").hide();
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $("#flash").hide();
                } //end buttons
            }); //end modal edit
        }
    }); //end ajax call
}); //end edit