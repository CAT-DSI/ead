function showNotification(div, type, message, timeout) {
    if (isNotEmpty($("#" + div).html())) {
        $("#" + div).dxToast("hide");
    }

    $("#" + div).dxToast({
        message: message,
        type: type,
        position: {
            my: "top center",
            at: "top center",
            of: "#" + div
        },
        displayTime: timeout,
        width: 750
    });

    $("#" + div).dxToast("show");
}