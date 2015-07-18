(function () {
    angular.module('SquareRoute')
        .controller('LoginController', LoginController)

    function LoginController(loginService, $location) {
        var vm = this;
        vm.message = "Login View";

        vm.login = function () {
            loginService.login(vm.username, vm.password).then(loginSuccess, loginFail);
        }
        function loginSuccess() {
            $location.path('/welcome');
        }
        function loginFail() {
        }
    }


})();