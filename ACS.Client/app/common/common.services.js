(function() {
    "use strict";

    angular.module("common.services", ["ngResource"])
        .constant("appSettings", {
            serverpath: 'http://localhost:64834/'
        });

}());