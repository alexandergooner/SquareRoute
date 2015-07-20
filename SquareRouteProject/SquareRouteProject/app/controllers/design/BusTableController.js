(function () {
    angular.module('SquareRoute')
        .controller('BusTableController', BusTableController)

    function BusTableController($scope) {
        var vm = this;



        //$scope.removeRow = function (busStopId) {
        //    console.log("SHIT");
        //    var index = -1;
        //    var busStopArr = eval($scope.vm.result);
        //    for (var i = 0; i < busStopArr.length; i++) {
        //        if (busStopArr[i].busStopId === busStopId) {
        //            index = i;
        //            break;
        //        }
        //    }
        //    if (index === -1) {
        //        alert('Error');
        //    }
        //    $scope.result.splice(index, 1);
        //};

        //$scope.editRow = function (busStopId) {
        //    console.log(route);
        //    var busStopArr = eval($scope.busStops);
        //    for (var i = 0; i < busStopArr.length; i++) {
        //        if (busStopArr[i].busStopId === busStopId) {
        //            $scope.busStopId = ' ';
        //            $scope.location = ' ';
        //            $scope.routeId = ' ';
        //        }
        //    }
        //}



    }

})();