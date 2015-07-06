(function () {

    angular.module('SquareRoot', ['ngRoute']).config(Config);

    function Config($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: '/app/views/welcome.html'
            , controller: 'WelcomeLoginController',
            controllerAs: 'vm'
        })
        .when('/parent', {
            templateUrl: '/app/views/parent.html',
            controller: 'ParentController',
            controllerAs: 'vm'
        }).when('/driver', {
            templateUrl: '/app/views/driver.html'
            , controller: 'DriverController',
            controllerAs: 'vm'
        })
        .when('/dispatcher', {
            templateUrl: '/app/views/dispatcher.html'
            , controller: 'DispatcherController',
            controllerAs: 'vm'
        })
        .when('/admin', {
            templateUrl: '/app/views/admin.html'
            , controller: 'AdminController',
            controllerAs: 'vm'
        })
            .when('/login', {
                templateUrl: '/app/views/login.html'
            , controller: 'LoginController',
                controllerAs: 'vm'
            })
            .when('/registration', {
                templateUrl: '/app/views/registration.html'
            , controller: 'RegistrationController',
                controllerAs: 'vm'
            })


        

        }

        })();