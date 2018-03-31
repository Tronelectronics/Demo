function updateEntity(entityJSON, url) {
    $.ajax({
        contentType: "application/json",
        data: JSON.stringify(entityJSON),
        type: "POST",
        url: url,
        success: function (msg) {
            //alert(JSON.stringify(msg));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
            alert(XMLHttpRequest.readyState);
            alert(XMLHttpRequest.status);
            alert(XMLHttpRequest.statusText);
            alert(textStatus);
        },
        complete: function (XMLHttpRequest, textStatus) {

        }
    });
}