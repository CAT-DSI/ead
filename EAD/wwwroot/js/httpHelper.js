function sendRequest(type, url, success, error, dataType = 'text') {
    $.ajax({
        type: type,
        url: url,
        success: success,
        error: error,
        dataType: dataType
    });
}

function sendRequest(type, url, success, error, data) {
    $.ajax({
        type: type,
        url: url,
        success: success,
        error: error,
        data: data,
        processData: false,
        contentType: false
    });
}

function getResponseText(url) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", url, false);
    xmlHttp.send(null);

    return xmlHttp.responseText;
}