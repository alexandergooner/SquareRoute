(function () {
    angular.module('SquareRoute')
        .controller('WelcomeLoginController', WelcomeLoginController)
        .controller('ParentController', ParentController)
        .controller('DriverController', DriverController)
        .controller('DispatcherController', DispatcherController)
        .controller('AdminController', AdminController)
        .controller('LoginController', LoginController)
        .controller('RegistrationController', RegistrationController)
        .controller('')



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


    function LoginController($scope, $location, $rootscope, AUTH_EVENTS, AuthService) {

        $scope.credentials = {
            username: '',
            password: ''
        };
        $scope.login = function (credentials) {

            AuthService.login(credentials).then(function (user) {
                $rootscope.$brodcast(AUTH_EVENTS.loginsucess);
                $scope.setCurrentUser(user);
            }, function () {
                $rootscope.$brodcast(AUTH_EVENTS.loginFailed)
            });
        };

       
    }


    function RegistrationController($scope, $location, $timeout, AuthService) {

        vm.savedSucessfully = false;
        vm.message = "";

        vm.registration = {
            userName: "",
            password: "",
            confirmPassword: ""
        };
        vm.signUp= function (){}
    

    }


})();


//function LoginController(loginService, $location, $rootscope) {

//    var vm = this;
//    vm.message = "Login View"
//}