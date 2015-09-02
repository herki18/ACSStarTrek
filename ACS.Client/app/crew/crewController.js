(function () {
    "use strict";

    angular.module("app")
        .controller("CrewController",
        ["crewResource", "$scope", "$modalInstance", "items",
            CrewController]);

    function CrewController(crewResource, $scope, $modalInstance, items) {

        crewResource.query(function (data) {
            $scope.crew = data;
            angular.forEach(items, function (value1, key1) {
                for (var i = 0; i < $scope.crew.length; i++) {
                    var value2 = $scope.crew[i];
                    if (value1.FirstUrl === value2.FirstUrl) {
                        $scope.selectedItems.push(value2);
                        break;
                    }
                }

            });
        });

        $scope.selectedItems = [];


        $scope.AddAndRemove = function(item) {
            var index = $scope.selectedItems.indexOf(item);
            if (index < 0) {
                $scope.selectedItems.push(item);
            } else {
                $scope.selectedItems.splice(index, 1);
            }
        }

        $scope.ok = function () {
            $modalInstance.close($scope.selectedItems);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        
    }
}());