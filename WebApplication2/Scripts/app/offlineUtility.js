var OfflineUtility = function (onlineCallback, offlineCallback, pollingUrl) {

    // *************************************************************
    // *** The following can be removed in production contexts *****
    // *************************************************************
    var DEBUG_MODE = true;
    // *************************************************************

    if (!pollingUrl) {
        pollingUrl = '/o.html';
    }

    var currentEventName = 'unknown';

    var fireEvent = function (name, data) {
        var e = document.createEvent("Event");
        e.initEvent(name, true, true);
        e.data = data;
        window.dispatchEvent(e);
    },

        fireEventIfStatusChanges = function (eventName) {
            if (currentEventName != eventName) {
                currentEventName = eventName;
                fireEvent(eventName, {});
            }
        },

        getUrl = function () {

            // *************************************************************
            // *** The following can be removed in production contexts *****
            // *************************************************************
            if ($('#offlineButton').text() === 'Offline') {
                return '/some-fake-page-on-your-server-to-force-the-offline-event.html';
            }
            // *************************************************************

            return pollingUrl;
        },


        // approach via @paul_kinlan http://bit.ly/ZYvJor
        detectOnlineStatus = function (url) {
            if (url !== undefined) {
                $.get(url).done(function () {
                    fireEventIfStatusChanges('onlineCustom');
                }).fail(function () {
                    fireEventIfStatusChanges('offlineCustom');
                });
            }
        },

        autoReloadOnCacheUpdate = function () {
            window.applicationCache.swapCache();
            location.reload();
        };

    // *************************************************************
    // *** The following can be removed in production contexts *****
    // *************************************************************
    if (DEBUG_MODE) {
        var btn = $('<button id="offlineButton" name="offlineButton" class="btn btn-primary btn-lg btn-default" onclick="if ($(this).text() === \'Offline\') {$(this).text(\'Online\');} else {$(this).text(\'Offline\');}" style="display:block; position:absolute; left:15px; bottom:15px;">Online</button>');

        $('body').append(btn);
    }
    // *************************************************************

    if (window.applicationCache) {
        $(window.applicationCache).on('updateready', autoReloadOnCacheUpdate);
    }

    if (onlineCallback) {
        window.addEventListener("onlineCustom", onlineCallback);
    }

    if (offlineCallback) {
        window.addEventListener("offlineCustom", offlineCallback);
    }

    if (onlineCallback || offlineCallback) {
        detectOnlineStatus();
        setInterval(function () {
            var url = getUrl();
            detectOnlineStatus(url);
        }, 3000);
    }

};
// */

// ****************************************************************** //
// The following version of OfflineUtility uses the native browser 
// implementaiton of online detection using the window.online
// and window.offline events in conjunction with the navigator.onLine
// property. This approach is effective, but not supported by 
// all browers in the same way. For instance FireFox does not raise
// the online/offline events when connectivity is lost from the browser.
// If this is not an issue for you then this version of OfflineUtility
// may be a good choice for your application.
// ****************************************************************** //
/*
var OfflineUtility = function(onlineCallback, offlineCallback) {
    var
        autoReloadOnCacheUpdate = function() {
            window.applicationCache.swapCache();
            location.reload();
        };
    if (onlineCallback) {
        $(window).on('online', onlineCallback);
    }
    if (offlineCallback) {
        $(window).on('offline', offlineCallback);
    }
    if (window.applicationCache) {
        $(window.applicationCache).on('updateready', autoReloadOnCacheUpdate);
    }
    if (navigator.onLine) {
        onlineCallback();
    } else {
        offlineCallback();
    }
};
// */