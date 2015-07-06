(function () {
    angular.module('SquareRoot').controller('WelcomeLoginController', WelcomeLoginController)
    .controller('ParentController', ParentController)
    .controller('DispatcherController', DispatcherController)
    .controller('RegistrationController', RegistrationController)
    .controller('DriverController', DriverController)
    .controller('AdminController', AdminController)


    function WelcomeLoginController() {


        var vm = this;

        vm.message = "Welcome Login";
    }

    function ParentController() {


        var vm = this;

        vm.message = ""
    }

    function DriverController() {


        var vm = this;

        vm.message = "Driver  "
    }

    function DispatcherController() {


        var vm = this;

        vm.message = "Dispatcher"
    }

    function AdminController() {


        var vm = this;

        vm.message = "Admin "
    }

    //function LoginController() {


    //    var vm = this;

    //    vm.message = "Welcome Login "
    //}

    function RegistrationController() {


        var vm = this;

        vm.message = "Registration "
    }






})();