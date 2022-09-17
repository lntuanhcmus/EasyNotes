var namespace = function (ns_string) {
    var parts = ns_string.split('.');
    var parent = this;
    var i;

    //Ignore if this is root (vd là MYAPP)
    if (window[parts[0]] === this) {
        parts = parts.slice(1);
    }

    for (i = 0; i < parts.length; i += 1) {
        // create if not exist
        if (typeof parent[parts[i]] === "undefined") {
            parent[parts[i]] = {};
        }
        parent = parent[parts[i]];
    }

    return parent;
};

var webApp = webApp || {};
webApp.namespace = namespace;
