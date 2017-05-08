'use strict';

class Requester {

    request(url, type, body, headers) {

        let promise = new Promise(function (resolve, reject) {
            $.ajax({
                url,
                type,
                headers,
                data: body,
                success: resolve,
                error: reject,
                contentType: 'application/json'
            });
        });

        return promise;
    }

    get(url, headers = {}) {
        return this.request(url, 'GET', '', headers);
    }

    post(url, body, headers = {}) {
        return this.request(url, 'POST', JSON.stringify(body), headers);
    }

    put(url, body, headers = {}) {
        return this.request(url, 'PUT', JSON.stringify(body), headers);
    }
}

export default new Requester();
