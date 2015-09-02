(function() {
    "use strict";

    var app = angular.module("app",
        ["common.services", "ui.bootstrap"])
        .provider({
            $exceptionHandler: function(){
                var handler = function(exception, cause) {
                    exception.message += ' (caused by "' + cause + '")';
                    throw exception;
                };

                this.$get = function() {
                    return handler;
                };   
            }
        });


}());