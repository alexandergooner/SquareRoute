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
                routes: {
                    //Put the lat/lng routes here
                    start: [
                        { name: 'Houston, Texas', latlng: '29.7632800,-95.3632700' },
                        { name: 'Chicago, Illinois', latlng: '41.8500300,-87.6500500' }
                    ],
                    ways: [
                        { name: 'Las Vegas, Nevada', latlng: '36.114647,-115.172813' },
                        { name: 'New York, New York', latlng: '40.7142700,-74.0059700' }
                    ],
                    end: [
                         { name: 'Houston, Texas', latlng: '29.7632800,-95.3632700' },
                         { name: 'Chicago, Illinois', latlng: '41.8500300,-87.6500500' }
                    ]
                }
            },
            routePoints: {
                start: {},
                end: {}
            }
        });

        $scope.routePoints.start = $scope.map.routes.start[0];
        $scope.routePoints.end = $scope.map.routes.end[1];

        uiGmapGoogleMapApi.then(function (maps) {
            var directionsDisplay = new maps.DirectionsRenderer();

            $scope.calcRoute = function (routePoints) {
                var ways = [];
                for (var i = 0; i < routePoints.ways.length; i++) {
                    ways.push({
                        location: routePoints.ways[i].latlng,
                        stopover: true
                    });
                };

                var directionsService = new maps.DirectionsService();

                directionsDisplay.setMap($scope.map.control.getGMap());
                var start = routePoints.start.latlng;
                var end = routePoints.end.latlng;
                var request = {
                    origin: start,
                    destination: end,
                    waypoints: ways,
                    optimizeWaypoints: true,
                    travelMode: maps.TravelMode.DRIVING
                };
                directionsService.route(request, function (response, status) {
                    console.log(response);
                    if (status == maps.DirectionsStatus.OK) {
                        directionsDisplay.setDirections(response);
                    }
                });
                return;
            };
        });
        
    }
})();




