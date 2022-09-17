(function () {
    webApp.namespace("webApp.helper.request");
    webApp.helper.request = (function () {
        return {
            get: function (url, successCallback, failCallback) {
                $.ajax({
                    type: "GET",
                    url: url,
                    success: function (response, textStatus, jqXhr) {
                        if (_.isFunction(successCallback)) {
                            successCallback(response, textStatus, jqXhr);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        if (_.isFunction(failCallback)) {
                            failCallback(jqXhr, textStatus, errorThrown)
                        }
                    }
                });
            },

            post: function (url, data, successCallback, failCallback, timeoutValue) {
                var requestTimeout = 60000;

                if (timeoutValue && timeoutValue > 0) {
                    requestTimeout = timeoutValue;
                }

                $.ajax({
                    url: url,
                    type: "POST",
                    data: data,
                    contentType: "application/x-www-form-urlencoded",
                    success: function (response, textStatus, jqXhr) {
                        if (_.isFunction(successCallback)) {
                            if (response.ok && response.redirected == true) {
                                window.location.href = response.url;
                                return;
                            }

                            successCallback(response, textStatus, jqXhr);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        if (_.isFunction(failCallback)) {
                            failCallback(jqXhr, textStatus, errorThrown);
                        }
                    },
                    timeout: requestTimeout
                });
            },

            getAsync: async function getAsyncFn(url) {
                return await fetch(url);
            },

            postAsync: async function postAsyncFn(url, data) {
                return await fetch(url, {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(data)
                }).then(response => {
                    if (response.ok && response.redirected === true) {
                        window.location.href = response.url;
                        return;
                    }
                    return response;
                });
            }
        }
    }());
}());