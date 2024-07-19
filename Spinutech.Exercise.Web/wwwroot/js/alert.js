"use strict";

class Alert {
    static Error(messages) {
        if (Array.isArray(messages)) {
            alert('Errors:\n' + messages.join('\n'));
        } else {
            alert('Error: ' + messages);
        }
    }
}