(function () {
    angular.module('SquareRoute')
        .controller('DispatcherController', DispatcherController)

    function DispatcherController(busStopService) {
        var vm = this;
        vm.message = "Dispatcher View";


        vm.routes = [
            {
                routeId: 1,
                routeName: "Route 1"
            },
            {
                routeId: 2,
                routeName: "Route 2"
            },
            {
                routeId: 3,
                routeName: "Route 3"
            },
            {
                routeId: 4,
                routeName: "Route 4"
            },
            {
                routeId: 5,
                routeName: "Route 5"
            }

        ];


        // ______BUS STOPS_________
        // BusStop ADD Methods
        vm.addBusStop = function () {
            vm.input = {
                Location: vm.busStopLocation_Add,
                RouteId: vm.busStopRouteId_Add
            };

            busStopService.addBusStop(vm.input).then(callSuccess, callFail);
        }


        // BusStop GET Methods
        vm.getBusStopId = function () {
            vm.input = vm.busStopId_Get;

            busStopService.getBusStopId(vm.input).then(callSuccess, callFail);
        }
        vm.getBusStopsByRouteId = function () {
            vm.input = vm.busStopRouteId_Get;

            busStopService.getBusStopsByRouteId(vm.input).then(callSuccess, callFail);
        }
        vm.getAllBusStops = function () {
            busStopService.getAllBusStops().then(callSuccess, callFail);
        }

        // BusStop UPDATE Methods
        vm.updateBusStop = function () {
            vm.input = {
                BusStopId: vm.busStopId_Update,
                Location: vm.busStopLocation_Update,
                RouteId: vm.busStopRouteId_Update
            };

            busStopService.updateBusStop(vm.input).then(callSuccess, callFail);
        }



        // _______ROUTE____________
        // Route ADD Methods
        vm.addRoute = function () {
            vm.input = {
                RouteNum: vm.routeNum_Add,
                RouteStart: vm.routeStart_Add,
                RouteEnd: vm.routeEnd_Add,
                AccessCodeId: vm.routeAccessCodeId_Add,
                DistrictId: vm.routeDistrictId_Add
            };

            routeService.addRoute(vm.input).then(callSuccess, callFail);
        }

        // Route GET Methods
        vm.getRouteById = function () {

            vm.input = vm.routeId_Get;

            routeService.getRouteById(vm.input).then(callSuccess, callFail);
        }
        vm.getRouteByRouteNum = function () {

            vm.input = vm.routeRouteNum_Get;

            routeService.getRouteByRouteNum(vm.input).then(callSuccess, callFail);
        }
        vm.getRoutesByDistrictId = function () {

            vm.input = vm.routeDistrictId_Get;

            routeService.getRouteByDistrictId(vm.input).then(callSuccess, callFail);
        }
        vm.getAllRoutes = function () {
            routeService.getAllRoutes().then(callSuccess, callFail);
        }

        // Route UPDATE Methods
        vm.updateRoute = function () {

            vm.input = {
                RouteId: vm.routeId_Update,
                RouteNum: vm.routeNum_Update,
                RouteStart: vm.routeStart_Update,
                RouteEnd: vm.routeEnd_Update,
                AccessCodeId: vm.routeAccessCodeId_Update,
                DistrictId: vm.routeDistrictId_Update
            };

            routeSerice.updateRoute(vm.input).then(callSuccess, callFail);
        }

        // Route DELETE Methods
        vm.deleteRouteById = function () {
            vm.input = vm.routeId_Delete;

            routeService.deleteRouteById(vm.input).then(callSuccess, callFail);
        }

        // Promise return Functions
        function callSuccess(data) {
            vm.result = data;
            console.log("Success");
            console.log(data);
        }
        function callFail(data) {
            vm.result = data;
            console.log("Failed in Dispatch Controller");
            console.log(data);
        }

    }
})();