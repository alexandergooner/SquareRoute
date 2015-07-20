(function () {
    angular.module('SquareRoute')
        .factory('gMapService', gMapService);

    //GMapService
    function gMapService(uiGmapGoogleMapApi, uiGmapIsReady, $q, $window, $rootScope) {
        var gMapService = {};

        gMapService.calcRoute = calcRoute;

        function calcRoute(start, busStops, end) {
            angular.extend($rootScope, {
                map: {
                    center: {
                        latitude: 29.7632800,
                        longitude: -95.3632700
                    },
                    zoom: 10,
                    control: {}
                }
            });

            uiGmapGoogleMapApi.then(function (maps) {
                var directionsDisplay = new maps.DirectionsRenderer();
                calculateRoute();

                function calculateRoute() {
                    var directionsService = new DirectionsService();

                    directionsDisplay.setMap($scope.map.control.getGmap());

                    var locationArray = [];
                    for (var i = 0; i < busStops.length; i++) {

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
                        optimizeWaypoints: true
                    };
                    directionsService.route(request, function (response, status) {
                        if (status == maps.DirectionsStatus.OK) {
                            directionsDisplay.setDirections(response);
                        }
                    });
                    UiGmapIsReady.promise()
                        .then(function (instances) {
                            var maps = instances[0].map;
                            //$scope.calculateRoute(maps);
                        })
                }
            })
        }
        return gMapService;
    }
})();