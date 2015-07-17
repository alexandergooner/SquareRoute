(function () {
    angular.module('SquareRoute')
        .controller('ModalController', ModalController)
        .controller('ModalInstanceController', ModalInstanceController)

    function ModalController($scope, $modal, $log) {
        var vm = this;

        $scope.items = ['Route 1', 'Route 2', 'Route 3'];

        $scope.animationsEnabled = true;

        $scope.open = function (size) {
            var modalInstance = $modal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceController',
                size: size,
                resolve: {
                    items: function () {
                        return $scope.items;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };
    };

    function ModalInstanceController($scope, $modalInstance, items) {
        var vm = this;

        $scope.items = items;
        $scope.selected = {
            item: $scope.items[0]
        };

        $scope.ok = function () {
            $modalInstance.close($scope.selected.item);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }

})();