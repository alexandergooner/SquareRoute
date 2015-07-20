(function () {
    angular.module('SquareRoute')
        .controller('GoogleMapsController', GoogleMapsController)

    // GOOGLE MAPS CONTROLLER
    function GoogleMapsController(busStopService, $scope, $http, uiGmapGoogleMapApi, uiGmapIsReady, $log) {
        var vm = this;
        vm.message = "GoogleMaps View";
        vm.result = [""];
        
        //GET BUS STOPS BY ROUTE ID
        vm.getBusStopsByRouteId = function () {
            var busStops = busStopService.getBusStopsByRouteId(1).then(callSuccess, callFail);
            console.log(busStops);
        }

        function callSuccess(data) {
            vm.result = data[0].Location;
            console.log("Success!")
            console.log(data);
        }
        function callFail(data) {
            vm.result = data;
            console.log("Failed!");
            console.log(data);
        }
        angular.extend($scope, {
            map: {
                center: {
                    latitude: 29.7632800,
                    longitude: -95.3632700
                },
                zoom: 10,
                control: {},
            },
        });

        uiGmapGoogleMapApi.then(function (maps) {
            var directionsDisplay = new maps.DirectionsRenderer();

            $scope.calcRoute = function (routePoints) {

                var directionsService = new maps.DirectionsService();

                directionsDisplay.setMap($scope.map.control.getGMap());

                var waypts = ['Noah St. and Scott St. Houston, Tx', 'Lidstone st. and Faucette st. Houston Tx', 'Munger St. and Broadmoor St. Houston Tx', 'Bell St. and Sampson St. Houston Tx', 'ALMEDA GENOA RD. & CHISWICK RD.'];
                //var waypts = [vm.result];
                var stops = [];
                for (var i in waypts)
                    stops.push({
                        location: waypts[i],
                        stopover: true
                    });

                var start = ' 4400 West 18th Street Houston, Texas';
                var end = '11625 Martindale Rd. Houston, TX';
                var request = {
                    origin: start,
                    destination: end,
                    waypoints: stops,
                    optimizeWaypoints: true,
                    travelMode: maps.TravelMode.DRIVING
                };
                directionsService.route(request, function (response, status) {
                    if (status == maps.DirectionsStatus.OK) {
                        directionsDisplay.setDirections(response);
                    }
                });
                uiGmapIsReady.promise()
                    .then(function (instances) {
                        var maps = instances[0].map;
                        $scope.calcRoute(maps);
                    });
            };
        });
    }
})();




