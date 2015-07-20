(function () {
    angular.module('SquareRoute').
        controller('RouteTableController', RouteTableController)

    function RouteTableController($scope, $http) {

        $scope.routes = [
            {
                'routeId': 4,
                'routeNum': 434,
                'routeStart': "4049 Woodshire St, Houston, TX",
                'routeEnd': "5909 West Loop South, Bellaire, TX"
            }
        ];




        $scope.addRow = function () {
            $scope.routes.push({
                'routeId': $scope.routeId,
                'routeNum': $scope.routeNum,
                'routeStart': $scope.routeStart,
                'routeEnd': $scope.routeEnd,
                'busStops': $scope.busStops
            });
            $scope.routeId = '';
            $scope.routeNum = '';
            $scope.routeStart = '';
            $scope.routeEnd = '';
            $scope.busStops = '';
        };

        $scope.removeRow = function (routeId) {
            var index = -1;
            var routeArr = eval($scope.routes);
            for (var i = 0; i < routeArr.length; i++) {
                if (routeArr[i].routeId === routeId) {
                    index = i;
                    break;
                }
            }
            if (index === -1) {
                alert('Error');
            }
            $scope.routes.splice(index, 1);
        };


    }

})();