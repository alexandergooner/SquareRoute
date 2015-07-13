(function () {
    angular.module('SquareRoute')
        .controller('AdminController', AdminController)

    function AdminController(busStopService,routeService,accessCodeService,userService) {
        var vm = this;
        vm.message = "Admin View";

        //METHODS
        //________AccessCode________        
        //AccessCode ADD Methods
        vm.addAccessCode = function () {

            vm.input = {
                AccessCodeValue: vm.accessCodeValue_Add,
                RouteId : vm.routeId
            };

            accessCodeService.addAccessCode(vm.input).then(callSuccess, callFail);
        }

        //AccessCode GET Methods
        vm.getAccessCodeById = function () {

            vm.input = vm.accessCodeId_Get;

            accessCodeService.getAccessCodeById(vm.input).then(callSuccess, callFail);
        }
        vm.getAccessCodeByValue = function () {

            vm.input = vm.accessCodeValue_Get;

            accessCodeService.getAccessCodeByValue(vm.input).then(callSuccess, callFail);
        }
        vm.getAccessCodeByRouteId = function () {

            vm.input = vm.accessCodeRouteId_Get;

            accessCodeService.getAccessCodeByRouteId(vm.input).then(callSuccess, callFail);
        }
        vm.getAllAccessCodes = function () {            
            accessCodeService.getAllAccessCodes().then().then(callSuccess, callFail);
        }

        //AccessCode UPDATE Methods
        vm.updateAccessCode = function () {

            vm.input = {
                AccessCodeId: vm.accessCodeId_Update,
                AccessCodeValue: vm.accessCodeValue_Update
            }

            accessCodeService.updateAccessCode(vm.input).then(callSuccess, callFail);
        }

        //AccessCode DELETE Methods
        vm.deleteAccessCodeById = function () {

            vm.input = vm.accessCodeId_Delete;

            accessCodeService.deleteAccessCodeById(vm.input).then(callSuccess, callFail);
        }

        //_________BusStop__________        
        //BusStop ADD Method
        vm.addBusStop = function () {
            busStopService.addBusStop(vm.input).then(callSuccess, callFail);
        }

        //BusStop GET Methods
        vm.getBusStopById = function () {
            busStopService.getBusStopById(vm.input).then(callSuccess, callFail);
        }
        vm.getBusStopsByRouteId = function () {
            busStopService.getBusStopsByRouteId(vm.input).then(callSuccess, callFail);
        }
        vm.getAllBusStops = function () {
            busStopService.getAllBusStops().then(callSuccess, callFail);
        }

        //BusStop UPDATE Methods
        vm.updateBusStop = function () {
            busStopService.updateBusStop(vm.input).then(callSuccess, callFail);
        }

        //BusStop DELETE Methods
        vm.deleteBusStopById = function () {
            busStopService.deleteBusStopById(vm.input).then(callSuccess, callFail);
        }

        //__________Route___________
        //Route ADD Method
        vm.addRoute = function () {
            routeService.addRoute(vm.input).then(callSuccess, callFail);
        }

        //Route GET Methods
        vm.getRouteById = function () {
            routeService.getRouteById(vm.input).then(callSuccess, callFail);
        }
        vm.getRouteByRouteNum = function () {
            routeService.getRouteByRouteNum(vm.input).then(callSuccess, callFail);
        }
        vm.getRoutesByDistrictId = function () {
            routeService.getRoutesByDistrictId(vm.input).then(callSuccess, callFail);
        }
        vm.getAllRoutes = function () {
            routeService.getAllRoutes().then(callSuccess, callFail);
        }

        //Route UPDATE Methods
        vm.updateRoute = function () {
            routeService.updateRoute(vm.input).then(callSuccess, callFail);
        }

        //Route DELETE Methods
        vm.deleteRouteById = function () {
            routeService.deleteRouteById(vm.input).then(callSuccess, callFail);
        }

        //Promise return Functions
        function callSuccess(data) {
            vm.result = data;
        }
        function callFail(data) {
            vm.result = data;
        }
            
    }
})();