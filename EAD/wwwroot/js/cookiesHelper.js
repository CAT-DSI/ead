function getCookie(cookieId) {
    var cookieArr = document.cookie.split(";");
    for (var i = 0; i < cookieArr.length; i++) {
        var cookiePair = cookieArr[i].split("=");
        if (cookieId == cookiePair[0].trim()) {
            return decodeURIComponent(cookiePair[1]);
        }
    }

    return null;
}

function setCookie(cookieId, value) {
    var cookie = cookieId + "=" + encodeURIComponent(value);
    cookie += "; expires=Fri, 31 Dec 9999 23:59:59 GMT";

    document.cookie = cookie;
}