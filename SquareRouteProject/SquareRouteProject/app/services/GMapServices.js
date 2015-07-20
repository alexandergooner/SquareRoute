(function () {
    angular.module('SquareRoute')
        .factory('gMapService', gMapService);

    //GMapService
    function gMapService(uiGmapGoogleMapApi, UiGmapIsReady, $q, $window, $scope) {
        var gMapService = {};

        gMapService.calcRoute = calcRoute;


        angular.extend($scope, {
            map: {
                center: {
                    latitude: 29.7632800,
                    longitude: -95.3632700
                },
                zoom: 10,
                control: {}
            }
        });

        function calcRoute(start, waypoints, end, maps) {
            uiGmapGoogleMapApi.then(function (maps) {
                var directionsDisplay = new maps.DirectionsRenderer();

                $scope.calculateRoute = function () {
                    var directionsService = new DirectionsService();

                    directionsDisplay.setMap($scope.map.control.getGmap());

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
                            $scope.calculateRoute(maps);
                        })
                }
            })
        }
    }
})();