if (window.jQuery) {
    function showNotification(message) {
        if (jQuery('#downtimeNotification').length === 0) {
            jQuery('#ContentEditor').prepend(message);
        }
    }
}