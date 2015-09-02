(function () {
    "use strict";

    angular.module("common.services")
        .factory("crewManifestResource",
        ["$resource", "appSettings", crewManifestResource]);

    function crewManifestResource($resource, appSettings) {
        return $resource(appSettings.serverpath + "/api/CrewManifests/:id");
    }


}());