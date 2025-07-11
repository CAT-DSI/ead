var CATApps = (function () {
    var DRAWER_OPENED_KEY = "CATApps-drawer-opened";

    var breakpoints = {
        xSmallMedia: window.matchMedia("(max-width: 599.99px)"),
        smallMedia: window.matchMedia("(min-width: 600px) and (max-width: 959.99px)"),
        mediumMedia: window.matchMedia("(min-width: 960px) and (max-width: 1279.99px)"),
        largeMedia: window.matchMedia("(min-width: 1280px)")
    };

    function getDrawer() {
        return $("#layout-drawer").dxDrawer("instance");
    }

    function restoreDrawerOpened() {
        var isLarge = breakpoints.largeMedia.matches;
        if (!isLarge) {
            return false;
        }

        var state = sessionStorage.getItem(DRAWER_OPENED_KEY);
        if (state === null) {
            return isLarge;
        }

        return state === "true";
    }

    function saveDrawerOpened() {
        sessionStorage.setItem(DRAWER_OPENED_KEY, getDrawer().option("opened"));
    }

    function updateDrawer() {
        var isXSmall = breakpoints.xSmallMedia.matches;

        getDrawer().option({
            minSize: isXSmall ? 0 : 60
        });

        if (isXSmall) {
            getDrawer().hide();
        }
    }

    function init() {
        $("#layout-drawer-scrollview").dxScrollView({ direction: "vertical", useNative: true });

        $.each(breakpoints, function (_, size) {
            size.addListener(function (e) {
                if (e.matches) {
                    updateDrawer();
                }
            });
        });
        updateDrawer();

        $('.layout-body').removeClass('layout-body-hidden');
    }

    function onMenuButtonClick() {
        getDrawer().toggle();
        saveDrawerOpened();
    }

    function navigate(url, delay) {
        if (url) {
            setTimeout(function () { location.href = url }, delay);
        }
    }

    function onTreeViewItemClick(e) {
        var przekierowaniePoPierwszymKliknieciu = true;

        if (przekierowaniePoPierwszymKliknieciu) {
            navigate(e.itemData.path, 0);
        }
        else {
            var drawer = getDrawer();
            var savedOpened = restoreDrawerOpened();
            var actualOpened = drawer.option("opened");

            if (!actualOpened) {
                drawer.show();
            } else {
                var willHide = !savedOpened || !breakpoints.largeMedia.matches;
                var willNavigate = !e.itemData.selected;

                if (willHide) {
                    drawer.hide();
                }

                if (willNavigate) {
                    navigate(e.itemData.path, willHide ? 400 : 0);
                }
            }
        }
    }

    return {
        init: init,
        restoreDrawerOpened: restoreDrawerOpened,
        onMenuButtonClick: onMenuButtonClick,
        onTreeViewItemClick: onTreeViewItemClick
    };
})();

document.addEventListener("DOMContentLoaded", function documentReady() {
    this.removeEventListener("DOMContentLoaded", documentReady);
    CATApps.init();
});