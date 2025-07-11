function displayPopup(id) {
    var dxPopup = $("#" + id).dxPopup("instance");
    if (dxPopup !== undefined) {
        dxPopup.show();
    }
}

function getAutocompleteValue(id) {
    var dxAutocomplete = $("#" + id).dxAutocomplete("instance");

    return dxAutocomplete !== undefined ? dxAutocomplete.option('value') : null;
}

function setAutocompleteValue(id, value) {
    var dxAutocomplete = $('#' + id).dxAutocomplete('instance');
    if (dxAutocomplete !== undefined) {
        dxAutocomplete.option('value', value);
    }
}

function getDateBoxValue(id) {
    var dxDateBox = $("#" + id).dxDateBox("instance");

    return dxDateBox !== undefined ? dxDateBox.option('value') : null;
}

function setDateBoxValue(id, value) {
    var dxDateBox = $('#' + id).dxDateBox('instance');
    if (dxDateBox !== undefined) {
        dxDateBox.option('value', value);
    }
}

function getSelectBoxValue(id) {
    var dxSelectBox = $("#" + id).dxSelectBox("instance");

    return dxSelectBox !== undefined ? dxSelectBox.option('value') : null;
}

function getSelectBoxText(id) {
    var dxSelectBox = $("#" + id).dxSelectBox("instance");

    return dxSelectBox !== undefined ? dxSelectBox.option('text') : null;
}

function setSelectBoxValue(id, value) {
    var dxSelectBox = $('#' + id).dxSelectBox('instance');
    if (dxSelectBox !== undefined) {
        dxSelectBox.option('value', value);
    }
}

function getTagBoxSelectedItems(id) {
    var dxTagBox = $("#" + id).dxTagBox("instance");

    return dxTagBox !== undefined ? dxTagBox.option('selectedItems') : null;
}

function getRadioGroupValue(id) {
    var dxRadioGroup = $("#" + id).dxRadioGroup("instance");

    return dxRadioGroup !== undefined ? dxRadioGroup.option('value') : null;
}

function getTextBoxValue(id) {
    var dxTextBox = $("#" + id).dxTextBox("instance");

    return dxTextBox !== undefined ? dxTextBox.option('value') : null;
}

function setTextBoxValue(id, value) {
    var dxTextBox = $('#' + id).dxTextBox('instance');
    if (dxTextBox !== undefined) {
        dxTextBox.option('value', value);
    }
}

function getNumberBoxValue(id) {
    var dxNumberBox = $("#" + id).dxNumberBox("instance");

    return dxNumberBox !== undefined ? dxNumberBox.option('value') : null;
}

function setNumberBoxValue(id, value) {
    var dxNumberBox = $('#' + id).dxNumberBox('instance');
    if (dxNumberBox !== undefined) {
        dxNumberBox.option('value', value);
    }
}

function getTextAreaValue(id) {
    var dxTextArea = $("#" + id).dxTextArea("instance");

    return dxTextArea !== undefined ? dxTextArea.option('value') : null;
}

function setTextAreaValue(id, value) {
    var dxTextArea = $('#' + id).dxTextArea('instance');
    if (dxTextArea !== undefined) {
        dxTextArea.option('value', value);
    }
}

function getFileUploaderValue(id) {
    var dxFileUploader = $("#" + id).dxFileUploader("instance");

    return dxFileUploader !== undefined ? dxFileUploader.option('value') : null;
}

function reloadDateGridDetails(e) {
    var detailRowIndex = e.component.getRowIndexByKey(e.key) + 1,
        $detailCell = e.component.getCellElement(detailRowIndex, 0).parent().find(".dx-master-detail-cell"),
        dataGrid = $detailCell.find(".dx-datagrid").first().parent().dxDataGrid("instance");

    if (dataGrid != undefined) {
        dataGrid.refresh();
    }
}

function reloadDataGridSource(id) {
    var dxDataGrid = $("#" + id).dxDataGrid('getDataSource');
    if (dxDataGrid !== undefined) {
        dxDataGrid.reload();
    }
}

function reloadSelectBoxSource(id) {
    var dxSelectBox = $("#" + id).dxSelectBox('getDataSource');
    if (dxSelectBox !== undefined) {
        dxSelectBox.reload();
    }
}

function resetSelectBox(id) {
    var dxSelectBox = $("#" + id).dxSelectBox('instance');
    if (dxSelectBox !== undefined) {
        dxSelectBox.reset();
    }
}

function resetTagBox(id) {
    var dxTagBox = $("#" + id).dxTagBox('instance');
    if (dxTagBox !== undefined) {
        dxTagBox.reset();
    }
}

function getDataGridCellValue(id, index, fieldName) {
    var dxDataGrid = $('#' + id).dxDataGrid('instance');

    return dxDataGrid !== undefined ? dxDataGrid.cellValue(index, fieldName) : null;
}

function setDataGridColumnVisible(id, fieldName, isVisible) {
    if ($('#' + id).dxDataGrid('instance') !== undefined) {
        $('#' + id).dxDataGrid("columnOption", fieldName, "visible", isVisible);
    }
}

function setDataGridColumnText(id, fieldName, caption) {
    if ($('#' + id).dxDataGrid('instance') !== undefined) {
        $('#' + id).dxDataGrid("columnOption", fieldName, "caption", caption);
    }
}

function resetFileUploader(id) {
    var dxFileUploader = $("#" + id).dxFileUploader("instance");
    if (dxFileUploader !== undefined) {
        dxFileUploader.reset();
    }
}

function getSwitchValue(id) {
    var dxSwitch = $('#' + id).dxSwitch('instance');

    return dxSwitch !== undefined ? dxSwitch.option('value') : false;
}

function setSwitchValue(id, value) {
    var dxSwitch = $('#' + id).dxSwitch('instance');
    if (dxSwitch !== undefined) {
        dxSwitch.option('value', value);
    }
}

function runOnConfirm(title, success) {
    var result = DevExpress.ui.dialog.confirm(title);
    $(".dx-dialog .dx-popup-title").remove();
    result.done(function (dialogResult) {
        if (dialogResult) {
            success();
        }
    });
}

function allowAdding(id, isAllow) {
    var dxDataGrid = $("#" + id).dxDataGrid("instance");
    if (dxDataGrid !== undefined) {
        dxDataGrid.option("editing.allowAdding", isAllow);
    }
}

function allowDeleting(id, isAllow) {
    var dxDataGrid = $("#" + id).dxDataGrid("instance");
    if (dxDataGrid !== undefined) {
        dxDataGrid.option("editing.allowDeleting", isAllow);
    }
}

function allowUpdating(id, isAllow) {
    var dxDataGrid = $("#" + id).dxDataGrid("instance");
    if (dxDataGrid !== undefined) {
        dxDataGrid.option("editing.allowUpdating", isAllow);
    }
}

function previewFile(popupId, title, filePath) {
    var popup = $("#" + popupId).dxPopup("instance");
    popup.option(
        {
            "title": title,
            "contentTemplate": "<embed src='" + filePath + "'width='100%' height='100%' type='application/pdf' />"
        });

    popup.show();
}

function downloadFile(filePath, fileName) {
    var a = document.createElement("a");
    a.href = filePath;
    a.setAttribute("download", fileName);
    a.click();
}

function validateForm(id) {
    var dxForm = $('#' + id).dxForm('instance');
    if (dxForm !== undefined) {
        return dxForm.validate().isValid;
    }
    else {
        return false;
    }
}

function setTextBoxRequired(id, isRequired) {
    var dxTextBox = $('#' + id).dxTextBox('instance');
    if (dxTextBox !== undefined) {
        dxTextBox.option('required', isRequired);
    }
}

const setDataGridSource = (id, source) => {
    const dxDataGrid = $(`#${id}`).dxDataGrid('instance');
    if (dxDataGrid) {
        dxDataGrid.option('dataSource', source);
        dxDataGrid.getDataSource().reload();
    }
};

function setDateBoxRequired(id, isRequired) {
    var dxDateBox = $('#' + id).dxDateBox('instance');
    if (dxDateBox !== undefined) {
        dxDateBox.option('required', isRequired);
    }
}