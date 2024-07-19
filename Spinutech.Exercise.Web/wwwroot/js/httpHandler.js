"use strict";

class HttpHandler {
    static async post({ url, data }) {
        let response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            let errorData = await response.json();
            return Promise.reject(errorData);
        }

        return response.json();
    }
}
