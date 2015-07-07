(function () {
    angular.module('SquareRoute')
        .controller('WelcomeLoginController', WelcomeLoginController)
        .controller('ParentController', ParentController)
        .controller('DriverController', DriverController)
        .controller('DispatcherController', DispatcherController)
        .controller('AdminController', AdminController)
        .controller('LoginController', LoginController)
        .controller('RegistrationController', RegistrationController)
        .controller('GoogleMapsController',GoogleMapsController)



    function WelcomeLoginController() {

        var vm = this;
        vm.message = "Welcome Login";
    }


    function ParentController() {

        var vm = this;
        vm.message = "Parent View"
    }


    function DriverController() {


        var vm = this;
        vm.message = "Driver View"
    }


    function DispatcherController() {

        var vm = this;
        vm.message = "Dispatcher View"
    }


    function AdminController() {

        var vm = this;
        vm.message = "Admin View"
    }


    function LoginController() {

        var vm = this;
        vm.message = "Login View"
    }


    function RegistrationController() {

        var vm = this;
        vm.message = "Registration View"

    }

    function GoogleMapsController($scope, uiGmapGoogleMapApi) {
        var vm = this;
        vm.message = "GoogleMaps View"

        var lat = 45;
        var lng = -73;
        var zoom = 8;

        $scope.map = { center: { latitude: lat, longitude: lng }, zoom: zoom };
        
        //directionsDisplay = new google.maps.DirectionsRenderer();        

        uiGmapGoogleMapApi.then(function (maps) {
            //directionsDisplay.setMap(maps);
        })
    }

})();