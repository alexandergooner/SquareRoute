(function () {
    angular.module('SquareRoute')
        .controller('RegistrationController', RegistrationController)

    function RegistrationController($location, registerService) {
        var vm = this;
        vm.message = "Registration View";

        vm.register = function () {
            registerService.register(vm.email, vm.createPassword, vm.confirmPassword, vm.roleType).then(registerSuccess, registerFail);
        }

        function registerSuccess() {
            $location.path('/menu');
        }
        function registerFail() {

        }
    }
})();