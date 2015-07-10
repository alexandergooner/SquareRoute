(function () {
    angular.module('SquareRoute')
        .controller('GoogleMapsController', GoogleMapsController)

    function GoogleMapsController($scope, uiGmapGoogleMapApi) {
        var vm = this;
        vm.message = "GoogleMaps View";

        var lat = 45;
        var lng = -73;
        var zoom = 8;

        $scope.map = { center: { latitude: lat, longitude: lng }, zoom: zoom };

        //directionsDisplay = new google.maps.DirectionsRenderer();

        uiGmapGoogleMapApi.then(function (maps) {
            //direectionsDisplay.setMap(maps);
        })
    }
})();