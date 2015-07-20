(function () {
    angular.module('SquareRoute')
        .controller('GoogleMapsController', GoogleMapsController)

    // GOOGLE MAPS CONTROLLER
    function GoogleMapsController(busStopService, $scope, $http, uiGmapGoogleMapApi, uiGmapIsReady, $log, gMapService) {
        var vm = this;
        vm.message = "GoogleMaps View";
        vm.result = [""];
        
        //GET BUS STOPS BY ROUTE ID
        vm.getBusStopsByRouteId = function() {
            busStopService.getBusStopsByRouteId(1).then(callSuccess, callFail);            
        }

        function callSuccess(data) {
            var start = '4400 West 18th Street Houston, Texas';
            var end = '11625 Martindale Rd. Houston, TX';

            //After getting all of the required data then make gMapService.calcRoute call
            gMapService.calcRoute(start, data, end, vm.map);
            console.log("Success!");
            console.log(data);
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
                vm.getBusStopsByRouteId(); 
            });
        //END___Needed for GoogleMap to work___
    }
})();




