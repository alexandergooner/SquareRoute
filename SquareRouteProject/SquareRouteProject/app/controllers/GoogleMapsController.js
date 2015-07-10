(function () {
    angular.module('SquareRoute')
        .controller('GoogleMapsController', GoogleMapsController)

    // GOOGLE MAPS CONTROLLER
    function GoogleMapsController($scope, uiGmapGoogleMapApi) {
        var vm = this;
        vm.message = "GoogleMaps View";

        var lat = 29.556638;
        var lng = -95.386371;
        var zoom = 8;

        $scope.map = { center: { latitude: lat, longitude: lng }, zoom: zoom };

        //directionsDisplay = new google.maps.DirectionsRenderer();

        uiGmapGoogleMapApi.then(function (maps) {
            //direectionsDisplay.setMap(maps);
        })
    }
})();