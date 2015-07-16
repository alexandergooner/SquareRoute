(function () {
    angular.module('SquareRoute')
        .controller('GoogleMapsController', GoogleMapsController)

    // GOOGLE MAPS CONTROLLER
    function GoogleMapsController($scope, $http, uiGmapGoogleMapApi, $log) {
        var vm = this;
        vm.message = "GoogleMaps View";

        uiGmapGoogleMapApi.then(function () {
            
            console.log("GmapGoogleMapApi ready");
            $scope.map = {
                center: {
                    latitude: 29.758943,
                    longitude: -95.361720
                },
                zoom: 10,        
            }

            var directionsDisplay = new google.maps.DirectionsRenderer();
            var directionsService = new google.maps.DirectionsService();
            var map;
            var stepDisplay;
            var markerArray = [];

            vm.initialize = function () {
                directionsService = new google.maps.DirectionsService();

                vm.rendererOptions = {
                    map: map
                }
                directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions);

                stepDisplay = new google.maps.InfoWindow();
            }

            vm.calcRoute = function () {
                var start = "6351 Pinemont, Houston, TX";
                var end = "5100 Maple St, Bellaire, TX";
                var waypts = [
                    { location: "4049 Woodshire St, Houston, TX", stopover: true },
                    { location: "10401 WOODWIND DR, Houston, TX", stopover: true },
                    { location: "4134 MCDERMED DR, Houston, TX" },
                    { location: "10113 BASSOON DR, Houston, TX" },
                    { location: "10114 WOODWIND DR, Houston, TX" },
                    { location: "4081 SILVERWOOD DR, Houston, TX" }
                ];

                var request = {
                    origin: start,
                    destination: end,
                    waypoints: waypts,
                    optimizeWaypoints: true,
                    travelMode: google.maps.TravelMode.DRIVING
                };
                console.log(request);
                console.log(JSON.stringify(request));

                directionsService.route(request, function (response, status) {
                    console.log(response, status);
                    if (status == google.maps.DirectionsStatus.OK) {
                        var warnings = document.getElementById('warnings_panel');
                        warnings.innerHTML = "" + response.routes[0].warnings + " ";                      
                        directionsDisplay.setDirections(response);
                        showSteps(response);
                        var route = response.routes[0];
                        var summaryPanel = document.getElementById('directions_panel');
                        summaryPanel.innerHTML = "";
                        for (var i = 0; i < route.legs.length; i++) {
                            var routeSegment = i + 1;
                            summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment + '</b><br>';
                            summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
                            summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                            summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
                        }
                    }
                });
            }
            var showSteps = function (directionResult) {
                var myRoute = directionResult.routes[0].legs[0];

                for (var i = 0; i < myRoute.steps.length; i++) {
                    var marker = new google.maps.Marker({
                        position: myRoute.steps[i].start_point,
                        map: map
                    });
                    function attachInstructionText(marker, text) {
                        google.maps.event.addListener(marker, 'click', function () {
                            stepDisplay.setContent(text);
                            stepDisplay.open(map, marker);
                        });
                    }
                }
            }
        })

        }

})();




//var geocoder = new google.maps.Geocoder();
//geocoder.geocode({
//    "address": "Houston, TX"
//}, function (results, status) {
//    console.log(results);
//    if (status == google.maps.GeocoderStatus.OK && results.length > 0) {
//        $scope.$apply(function () {
//            var location = results[0].geometry.location,
//                lat = location.lat();
//            lng = location.lng();
//            console.info("Latitude:" + lat);
//            console.info("Longitude:" + lng);

//            $scope.marker = {
//                id: 0,
//                coords: {
//                    latitude: lat,
//                    longitude: lng
//                },
//                options: {
//                    draggable: true
//                },
//                events: {
//                    dragend: function (marker, eventName, args) {
//                        $log.log('marker dragend');
//                        var lat = marker.getPosition().lat();
//                        var lon = marker.getPosition().lng();
//                        $log.log(lat);
//                        $log.log(lon);

//                        $scope.marker.options = {
//                            draggable: true,
//                            labelContent: "lat: " + $scope.marker.coords.latitude + ' ' + 'lon:' + $scope.marker.coords.longitude,
//                            labelAnchor: "100 0",
//                            labelClass: "marker-labels"
//                        };
//                    }
//                }
//            };
//        });
//    }
//});

//uiGmapGoogleMapApi
//    .then(function (maps) {
//        console.log("FUCK YOU");
//        $scope.map = {
//            center: {
//                latitude: 29.758943,
//                longitude: -95.361720
//            },
//            zoom: 10,
//        };
//        $scope.directionsService = new google.maps.DirectionsService();
//        $scope.directionsDisplay = new google.maps.DirectionsRenderer();
//    }).then(function (instances) {
//        console.log('uiGmapIsReady done');

//        var instanceMap = instances[0].map;
//        $scope.directionsDisplay.setMap(instanceMap);

//        $scope.directionsService.route(directionsServiceRequest, (function (response, status) {
//            console.log(response, status);
//            if (status == google.maps.DirectionsStatus.$http) {
//                $scope.directionsDisplay.setDirections(response);
//            }
//        }));
//    });

//uiGmapGoogleMapApi.then(function () {
//    console.log("LET'S GO!");
//    $scope.map = {
//        center: {
//            latitude: 29.758943,
//            longitude: -95.361720
//        },
//        zoom: 10,        
//    }
//    $scope.directionsDisplay = new google.maps.DirectionsRenderer();
//    $scope.directionsService = new google.maps.DirectionsService();
//    $scope.maps;

//    vm.initialize = function () {
//        //directionService = new google.maps.DirectionsService();
//        var houston = new google.maps.LatLng(29.556638, -95.386371);
//        var mapOptions = {
//            zoom: 10,
//            center: houston,
//            disableDefaultUI: true
//        }
//        $scope.map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
//        $scope.directionsDisplay.setMap(map);

//    }

//    vm.calcRoute = function () {
//        var start = "6351 Pinemont, Houston, TX";
//        var end = "5100 Maple St, Bellaire, TX";
//        var waypts = [
//            { location: "4049 Woodshire St, Houston, TX", },
//            { location: "10401 WOODWIND DR, Houston, TX" },
//            { location: "4134 MCDERMED DR, Houston, TX" },
//            { location: "10113 BASSOON DR, Houston, TX" },
//            { location: "10114 WOODWIND DR, Houston, TX" },
//            { location: "4081 SILVERWOOD DR, Houston, TX" }
//        ];

//        var request = {
//            origin: start,
//            destination: end,
//            waypoints: waypts,
//            optimizeWaypoints: true,
//            travelMode: google.maps.TravelMode.DRIVING
//        };
//        console.log(request);
//        console.log(JSON.stringify(request));



//        $scope.directionsService.route(request, function (response, status) {
//            console.log(response, status);
//            if (status == google.maps.DirectionsStatus.OK) {
//                $scope.directionsDisplay.setDirections(response);
//                var route = response.routes[0];
//                var summaryPanel = document.getElementById('directions_panel');
//                summaryPanel.innerHTML = "";
//                for (var i = 0; i < route.legs.length; i++) {
//                    var routeSegment = i + 1;
//                    summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment + '</b><br>';
//                    summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
//                    summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
//                    summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
//                }
//            }
//        });
//        google.maps.event.addDomListener(window, 'ng-load', vm.initialize);
//    }




