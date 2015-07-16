(function () {
    angular.module('SquareRoute')
        .controller('AdminController', AdminController);

    function AdminController(busStopService,routeService,accessCodeService,userService) {
        var vm = this;
        vm.message = "Admin View";

        //METHODS
        //________AccessCode________        
        //AccessCode ADD Methods
        vm.addAccessCode = function () {

            vm.input = {
                AccessCodeValue: vm.accessCodeValue_Add,
                RouteId: vm.accessCodeRouteId_Add
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
        vm.getAllAccessCodes = function () {            
            accessCodeService.getAllAccessCodes().then(callSuccess, callFail);
        }

        //AccessCode UPDATE Methods
        vm.updateAccessCode = function () {

            vm.input = {
                AccessCodeId: vm.accessCodeId_Update,
                AccessCodeValue: vm.accessCodeValue_Update,
                RouteId: vm.accessCodeRouteId_Update
            };

            accessCodeService.updateAccessCode(vm.input).then(callSuccess, callFail);
        }

        //AccessCode DELETE Methods
        vm.deleteAccessCodeById = function () {

            vm.input = vm.accessCodeId_Delete

            accessCodeService.deleteAccessCodeById(vm.input).then(callSuccess, callFail);
        }

        //_________BusStop__________        
        //BusStop ADD Method
        vm.addBusStop = function () {

            vm.input = {
                Location: vm.busStopLocation_Add,
                RouteId: vm.busStopRouteId_Add
            };

            busStopService.addBusStop(vm.input).then(callSuccess, callFail);
        }

        //BusStop GET Methods
        vm.getBusStopById = function () {

            vm.input = vm.busStopId_Get;

            busStopService.getBusStopById(vm.input).then(callSuccess, callFail);
        }
        vm.getBusStopsByRouteId = function () {

            vm.input = vm.busStopRouteId_Get;

            busStopService.getBusStopsByRouteId(vm.input).then(callSuccess, callFail);
        }
        vm.getAllBusStops = function () {            
            busStopService.getAllBusStops().then(callSuccess, callFail);
        }

        //BusStop UPDATE Methods
        vm.updateBusStop = function () {


            vm.input = {
                BusStopId: vm.busStopId_Update,
                Location: vm.busStopLocation_Update,
                RouteId: vm.busStopRouteId_Update
            };

            busStopService.updateBusStop(vm.input).then(callSuccess, callFail);
        }

        //BusStop DELETE Methods
        vm.deleteBusStopById = function () {

            vm.input = vm.busStopId_Delete;

            busStopService.deleteBusStopById(vm.input).then(callSuccess, callFail);
        }

        //__________Route___________
        //Route ADD Method
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

        //Route GET Methods
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

            routeService.getRoutesByDistrictId(vm.input).then(callSuccess, callFail);
        }
        vm.getAllRoutes = function () {
            routeService.getAllRoutes().then(callSuccess, callFail);
        }

        //Route UPDATE Methods
        vm.updateRoute = function () {

            vm.input = {
                RouteId: vm.routeId_Update,
                RouteNum: vm.routeNum_Update,
                RouteStart: vm.routeStart_Update,
                RouteEnd: vm.routeEnd_Update,
                AccessCodeId: vm.routeAccessCodeId_Update,
                DistrictId: vm.routeDistrictId_Update
            };

            routeService.updateRoute(vm.input).then(callSuccess, callFail);
        }

        //Route DELETE Methods
        vm.deleteRouteById = function () {

            vm.input = vm.routeId_Delete;

            routeService.deleteRouteById(vm.input).then(callSuccess, callFail);
        }

        //__________User___________
        //User Register[ADD] Method
        vm.registerUser = function () {

            vm.input = {
                Email: vm.email,
                Password: vm.createPassword,
                ConfirmPassword: vm.confirmPassword,
                FirstName: vm.firstName,
                LastName: vm.lastName,
                ImageUrl: vm.imageUrl,
                MobileDeviceId: vm.mobileDeviceId,
                Address: vm.addressLine1 + ' ' + vm.addressLine2,
                City: vm.city,
                State: vm.state,
                PostalCode: vm.postalCode
                //RoleType: 1                
            };

            userService.registerUser(vm.input).then(callSuccess, callFail);
        }

        //User GET Methods
        vm.getUsersByRoleType = function () {

            vm.input = vm.userRoleType_Get;

            userService.getUsersByRoleType(vm.input).then(callSuccess, callFail);
        }
        vm.getUserByEmail = function () {
            
            vm.input = vm.userByEmail_Get;

            userService.getUserByEmail(vm.input).then(callSuccess,callFail);
        }
        vm.getAllUsers = function () {
            
            userService.getAllUsers().then(callSuccess, callFail);
        }

        //User UPDATE Method
        vm.updateUser = function () {

            vm.input = vm.user;

            userService.updateUser(vm.input).then(callSuccess, callFail);
        }

        //User DELETE Mehod
        vm.deleteUser = function () {

            vm.input = vm.user;

            userService.deleteUser(vm.input).then(callSuccess,callFail)
        }

        //Promise return Functions
        function callSuccess(data) {
            vm.result = data;
            console.log("Success");
            console.log(data);
        }
        function callFail(data) {                        
            vm.result = data;
            console.log("Failed");
            console.log(data);
        }
            
    }
})();