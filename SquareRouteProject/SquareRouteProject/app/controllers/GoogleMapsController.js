(function () {
    angular.module('SquareRoute')
        .controller('GoogleMapsController', GoogleMapsController)

    // GOOGLE MAPS CONTROLLER
    function GoogleMapsController($scope, $http, uiGmapGoogleMapApi, uiGmapIsReady, $log) {
        var vm = this;
        vm.message = "GoogleMaps View";

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

                var waypts = ['Washington D.C', 'Las Vegas, Nevada', 'New York, New York', 'Indianapolis, Indiana'];
                var stops = [];
                for (var i in waypts)
                    stops.push({
                        location: waypts[i],
                        stopover: true
                    });

                var start = '157 S. Quentin Rd. Palatine, Illinois';
                var end = 'Las Angeles, California';
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




