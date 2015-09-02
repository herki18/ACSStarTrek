(function () {
    "use strict";

    angular.module("common.services")
        .factory("crewResource",
        ["$resource", "appSettings", crewResource]);

    function crewResource($resource, appSettings) {
        return $resource(appSettings.serverpath + "/api/Crew/:id");
    }

}());