function time_KeyDown(e) {
    var keyCode = e.event.keyCode;

    if (!((keyCode >= 48 && keyCode <= 57) || (keyCode >= 96 && keyCode <= 105) || keyCode === 186 || keyCode === 59 || keyCode === 46 || keyCode === 39 || keyCode === 37 || keyCode === 36 || keyCode === 35 || keyCode === 16 || keyCode === 8)) {
        e.event.preventDefault();
    }
}

function getLocalStorage(key) {
    localStorage.getItem(key);
}

function setLocalStorage(key, value) {
    localStorage.setItem(key, value);
}

function getSessionStorage(key) {
    sessionStorage.getItem(key);
}

function setSessionStorage(key, value) {
    sessionStorage.setItem(key, value);
}

function getNotEmpty(item1, item2) {
    return isNotEmpty(item1) ? item1 : item2;
}

function isNotEmpty(value) {
    return value !== undefined && value !== null && value.length > 0;
}

function redirectToUrl(url) {
    if (isNotEmpty(url)) {
        window.location.href = url;
    }
}

function openInNewTab(url) {
    if (isNotEmpty(url)) {
        var win = window.open(url, '_blank');
        win.focus();
    }
}

function openInNewWindow(url) {
    if (isNotEmpty(url)) {
        window.open(url, '_blank', 'location=yes,height=900,width=1280,scrollbars=yes,status=yes');
    }
}

function redirectToUrl(url, defaultUrl) {
    if (isNotEmpty(url)) {
        window.location.href = url;
    }
    else {
        window.location.href = defaultUrl;
    }
}

function setLabelValue(id, value) {
    $("#" + id).text(value);
}

function setLabelColor(id, color) {
    $("#" + id).css("color", color);
}

function hideOrShowControl(id, isShow) {
    if (isShow) {
        $("#" + id).show();
    }
    else {
        $("#" + id).hide();
    }
}

function getControlHtml(id) {
    return $("#" + id).html();
}

function setControlHtml(id, value) {
    if (isNotEmpty(id)) {
        document.getElementById(id).innerHTML = value;
    }
}

function getControlText(id) {
    return $("#" + id).val();
}

function setControlText(id, value) {
    if (isNotEmpty(id)) {
        $("#" + id).val(value)
    }
}

function setControlRequired(id, isRequired) {
    if (isRequired) {
        $("#" + id).attr('required', 'required');
    }
    else {
        $("#" + id).removeAttr('required');
    }
}

function setControlDisabled(id, isDisabled) {
    if (isDisabled) {
        $("#" + id).attr('disabled', 'disabled');
    }
    else {
        $("#" + id).removeAttr('disabled');
    }
}

function getListSelectedValue(id) {
    return $("#" + id).children("option:selected").val();
}

function setListSelectedValue(id, value) {
    $("#" + id).val(value).change();
}

function getIsCheckBoxChecked(id) {
    return jQuery("#" + id).prop("checked");
}

function setIsCheckBoxChecked(id, isChecked) {
    return jQuery("#" + id).prop('checked', isChecked);
}

function sortSelectItems(list, index) {
    if (isNotEmpty(list) && isNotEmpty(index)) {
        var select = jQuery('#' + list);
        select.html(select.find('option').sort(function (x, y) {
            return jQuery(x).text() > jQuery(y).text() ? 1 : -1;
        }));

        if (isNotEmpty(index)) {
            jQuery('#' + list).get(index).selectedIndex = 0;
        }
    }
}

function addListOption(id, item) {
    jQuery('#' + id).append('<option>' + item + '</option>');
}

String.prototype.toFirstUpperCase = function () {
    return this.charAt(0).toUpperCase() + this.slice(1)
}

String.prototype.removeDiacritics = function () {
    var diacritics = [
        { char: 'A', base: 'Ą' },
        { char: 'a', base: 'ą' },
        { char: 'C', base: 'Ć' },
        { char: 'c', base: 'ć' },
        { char: 'E', base: 'Ę' },
        { char: 'e', base: 'ę' },
        { char: 'L', base: 'Ł' },
        { char: 'l', base: 'ł' },
        { char: 'O', base: 'Ó' },
        { char: 'o', base: 'ó' },
        { char: 'S', base: 'Ś' },
        { char: 's', base: 'ś' },
        { char: 'Z', base: 'Ż' },
        { char: 'z', base: 'ż' },
        { char: 'Z', base: 'Ź' },
        { char: 'z', base: 'ź' },
    ]

    var str = this;

    diacritics.forEach(function (letter) {
        str = str.replace(letter.base, letter.char);
    });

    return str;
}

function formatDate(date) {
    return date[2] + '-' + addLeadingZeros(date[0]) + '-' + addLeadingZeros(date[1]);
}

function addLeadingZeros(value) {
    return value.length == 1 ? '0' + value : value;
}

function getStringParameter(name, value) {
    return value !== undefined && value !== null && value !== '' && value !== 0 ? '&' + name + '=' + value : '';
}

function getDateParameter(name, value) {
    return value !== undefined && value !== null && value !== '' && value !== 0 ? '&' + name + '=' + formatDate(value.toLocaleDateString("en-US").split('/')) : '';
}

function setCookie(value) {
    if (value !== undefined && value !== null && value.length > 0) {
        document.cookie = value;
    }
}