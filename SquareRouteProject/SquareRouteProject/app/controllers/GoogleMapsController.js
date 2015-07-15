(function () {
    angular.module('SquareRoute')
        .controller('GoogleMapsController', GoogleMapsController)

    // GOOGLE MAPS CONTROLLER
    function GoogleMapsController($scope, $http, uiGmapGoogleMapApi, $log) {
        var vm = this;
        vm.message = "GoogleMaps View";

        $scope.map = {
            center: { latitude: 29.758943, longitude: -95.361720 },
            zoom: 10,
        }
        
        uiGmapGoogleMapApi.then(function (maps) {
            directionsDisplay = new google.maps.DirectionsRenderer();
            directionsService = new google.maps.DirectionsService();
            var maps;
          
            vm.initialize = function () {
                directionService = new google.maps.DirectionsService();
                var houston = new google.maps.LatLng(29.556638, -95.386371);
                var mapOptions = {
                    zoom: 10,
                    center: houston,
                    disableDefaultUI: true
                }
                map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
                stepDisplay = new google.maps.InfoWindow();
                directionsDisplay.setMap('map-canvas');

            }

            vm.calcRoute = function() {
                var start = "Houston, TX";
                var end = "Dallas, TX";
                var waypts = [
                    { location: "Austin, TX", },
                    { location: "Galveston, TX" },
                    { location: "Waco, TX" },
                    { location: "El Paso, TX"}
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
                        directionsDisplay.setDirections(response);
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
                google.maps.event.addDomListener(window, 'ng-click', vm.initialize);
             }
        
             
             var geocoder = new google.maps.Geocoder();
             geocoder.geocode({
                 "address": "Houston, TX"
             }, function (results, status) {
                 console.log(results);
                 if (status == google.maps.GeocoderStatus.OK && results.length > 0) {
                     $scope.$apply(function () {
                         var location = results[0].geometry.location,
                             lat = location.lat();
                         lng = location.lng();
                         console.info("Latitude:" + lat);
                         console.info("Longitude:" + lng);

                         $scope.marker = {
                             id: 0,
                             coords: {
                                 latitude: lat,
                                 longitude: lng
                             },
                             options: {
                                 draggable: true
                             },
                             events: {
                                 dragend: function (marker, eventName, args) {
                                     $log.log('marker dragend');
                                     var lat = marker.getPosition().lat();
                                     var lon = marker.getPosition().lng();
                                     $log.log(lat);
                                     $log.log(lon);

                                     $scope.marker.options = {
                                         draggable: true,
                                         labelContent: "lat: " + $scope.marker.coords.latitude + ' ' + 'lon:' + $scope.marker.coords.longitude,
                                         labelAnchor: "100 0",
                                         labelClass: "marker-labels"
                                     };
                                 }
                             }
                         };
                     });
                 }
             });
        });

 
    }

})();


//$scope.polylines = [
//    {
//        id: 1,
//        path: [
//            {
//                latitude: 29.667151,
//                longitude: -95.442379
//            },
//            {
//                latitude: 29.669060, 
//                longitude: -95.443882
//            },
//            {
//                latitude: 29.668213,
//                longitude: -95.445765
//            }
//        ],
//        stroke: {
//            color: '#6060FB',
//            weight: 3
//        },
//        draggable: false,
//        editable: false,
//        geodesic: true,
//        visible: true
//    }
//]




