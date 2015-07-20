(function () {
    angular.module('SquareRoute')
        .controller('GoogleMapsController', GoogleMapsController)

    // GOOGLE MAPS CONTROLLER
    function GoogleMapsController(busStopService, routeService, routeDriverService, $scope, $http, uiGmapGoogleMapApi, uiGmapIsReady, $log, gMapService) {
        var vm = this;
        vm.message = "GoogleMaps View";
        vm.result = [""];
        vm.routeNum = "1401";

        //GET ROUTE BY ROUTE NUMBER
        vm.getRouteByRouteNum = function () {
            routeDriverService.getRouteDriverByRouteNum(vm.routeNum).then(callSuccess, callFail);
        }

        function callSuccess(routeDriver) {
            vm.routeStart = routeDriver.Route.RouteStart;
            vm.routeEnd = routeDriver.Route.RouteEnd;
            vm.busStops = routeDriver.Route.BusStops;
            vm.lat = routeDriver.Latitude;
            vm.lon = routeDriver.Longitude;
            //After getting all of the required data then make gMapService.calcRoute call
            gMapService.calcRoute(vm.routeStart, vm.busStops, vm.routeEnd, vm.map, vm.lat, vm.lon);
            console.log("Success!");
            console.log(routeDriver);
        }
        function callFail(data) {
            vm.result = data;
            console.log("Failed!");
            console.log(data);
        }

        //BEGIN___Needed for GoogleMap to work___
        vm.latitude = 29.7632800;
        vm.longitude = -95.3632700;
        vm.zoom = 10;
        
        angular.extend($scope, {
            map: {
                center: {
                    latitude: vm.latitude,
                    longitude: vm.longitude
                },
                zoom: vm.zoom,
                control: {},
            },
        });

        uiGmapIsReady.promise()
            .then(function (instances) {
                vm.map = instances[0].map;

                //Function Call to get data from database
                //vm.getBusStopsByRouteId();
                vm.getRouteByRouteNum();
            });
        //END___Needed for GoogleMap to work___
    }
})();




