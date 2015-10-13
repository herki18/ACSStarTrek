(function() {
    "use strict";

    angular.module("app")
        .controller("CrewManifestController",
        ["crewManifestResource", "$scope", "$modal", "$log",
            CrewManifestController]);

    function CrewManifestController(crewManifestResource, $scope, $modal, $log) {

        var vm = this;

        crewManifestResource.get(function(data) {
            $scope.crewManifest = data;
            vm.originalProduct = angular.copy(data);
        });

        console.error("hi");
        
        //ThrowException

        $scope.items = [];

        $scope.animationsEnabled = true;

        $scope.open = function (size, crewManifest) {
            var modalInstance = $modal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'app/crew/crew.html',
                controller: 'CrewController',
                size: size,
                resolve: {
                    items: function () {
                        return crewManifest;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.crewManifest.Crew = selectedItem;
                vm.submit();
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        vm.submit = function () {
            $scope.crewManifest.$save(function(data) {
                vm.originalProduct = angular.copy(data);
            });
        }

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };
    }
}());