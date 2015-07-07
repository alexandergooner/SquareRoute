(function () {
    angular.module('SquareRoute')
        .controller('WelcomeLoginController', WelcomeLoginController)
        .controller('ParentController', ParentController)
        .controller('DriverController', DriverController)
        .controller('DispatcherController', DispatcherController)
        .controller('AdminController', AdminController)
        .controller('LoginController', LoginController)
        .controller('RegistrationController', RegistrationController)



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


    function LoginController(loginService, $location) {

        var vm = this;
        vm.message = "Login View"
    }


    function RegistrationController() {

        var vm = this;
        vm.message = "Registration View"

    }


})();