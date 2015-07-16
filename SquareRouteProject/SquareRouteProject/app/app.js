(function () {

    angular.module('SquareRoute', ['ngRoute', 'uiGmapgoogle-maps', 'ui.bootstrap', 'ui.bootstrap.tpls', 'ngwidgets']).config(Config).config(ConfigGoogleMaps);

    function Config($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/app/views/welcome.html',
                controller: 'WelcomeController',
                controllerAs: 'vm'
            })
            .when('/parent', {
                templateUrl: '/app/views/parent.html',
                controller: 'ParentController',
                controllerAs: 'vm'
            })
            .when('/driver', {
                templateUrl: '/app/views/driver.html',
                controller: 'DriverController',
                controllerAs: 'vm'
            })
            .when('/dispatcher', {
                templateUrl: '/app/views/dispatcher.html',
                controller: 'DispatcherController',
                controllerAs: 'vm'
            })
            .when('/admin', {
                templateUrl: '/app/views/admin.html',
                controller: 'AdminController',
                controllerAs: 'vm'
            })
            .when('/login', {
                templateUrl: '/app/views/login.html',
                controller: 'LoginController',
                controllerAs: 'vm'
            })
            .when('/registration', {
                templateUrl: '/app/views/registration.html',
                controller: 'RegistrationController',
                controllerAs: 'vm'
            })
            .when('/googlemaps', {
                templateUrl: 'app/views/googlemaps.html',
                controller: 'GoogleMapsController',
                controllerAs: 'vm'
            })
            .when('/email', {
                templateUrl: 'app/views/emailTest.html',
                controller: 'EmailController',
                controllerAs: 'vm'
            })

    }

    function ConfigGoogleMaps(uiGmapGoogleMapApiProvider) {
        uiGmapGoogleMapApiProvider.configure({
            key: 'AIzaSyDIbkT55SIymEDsw4Eh7OzI4sBPIi3eiL8',
            v: '3.17',
            libraries: 'weather,geometry,visualization'
        });
    }

})();
//a
