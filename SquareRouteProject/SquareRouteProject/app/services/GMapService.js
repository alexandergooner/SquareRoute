(function () {
    angular.module('SquareRoute')
        .factory('gMapService', gMapService);

    //GMapService
    function gMapService(uiGmapGoogleMapApi, uiGmapIsReady, $q, $window, $rootScope) {
        var gMapService = {};

        gMapService.calcRoute = calcRoute;

        function calcRoute(start, busStops, end, map) {

            uiGmapGoogleMapApi.then(function (maps) {
                var directionsDisplay = new maps.DirectionsRenderer();
                calculateRoute();

                function calculateRoute() {
                    var directionsService = new maps.DirectionsService();

                    directionsDisplay.setMap(map);

                    var locationArray = [];
                    for (var i = 0; i < busStops.length; i++) {
                        locationArray.push(busStops[i].Location);
                    }

                    var waypoints = [];
                    for (var i in locationArray) {
                        waypoints.push({
                            location: locationArray[i],
                            stopover: true
                        });
                    }
                    
                    var request = {
                        origin: start,
                        destination: end,
                        waypoints: waypoints,
                        optimizeWaypoints: true,
                        travelMode: maps.TravelMode.DRIVING
                    };

                    directionsService.route(request, function (response, status) {
                        if (status == maps.DirectionsStatus.OK) {
                            directionsDisplay.setDirections(response);
                        }
                    });
                }
            })
        }
        return gMapService;
    }
})();