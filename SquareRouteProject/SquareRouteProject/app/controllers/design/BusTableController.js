(function () {
    angular.module('SquareRoute')
        .controller('BusTableController', BusTableController)

    function BusTableController($scope) {
        var vm = this;

        $scope.busStops = [
            {
                'busStopId': 6,
                'location': '4345 Fake St, Houston, TX',
                'routeId': 65
            },
            {
                'busStopId': 7,
                'location': '7654 Fake Ave, Houston, TX',
                'routeId': 23
            }
        ];


        $scope.addRow = function () {
            $scope.busStops.push({
                'busStopId': $scope.busStopId,
                'location': $scope.location,
                'routeId': $scope.routeId,
            });
            $scope.busStopId = '';
            $scope.location = '';
            $scope.routeId = '';

        };

        $scope.removeRow = function (busStopId) {
            console.log("SHIT");
            var index = -1;
            var busStopArr = eval($scope.vm.result);
            for (var i = 0; i < busStopArr.length; i++) {
                if (busStopArr[i].busStopId === busStopId) {
                    index = i;
                    break;
                }
            }
            if (index === -1) {
                alert('Error');
            }
            $scope.result.splice(index, 1);
        };

        $scope.editRow = function (busStopId) {
            console.log(route);
            var busStopArr = eval($scope.busStops);
            for (var i = 0; i < busStopArr.length; i++) {
                if (busStopArr[i].busStopId === busStopId) {
                    $scope.busStopId = ' ';
                    $scope.location = ' ';
                    $scope.routeId = ' ';
                }
            }
        }



    }

})();