(function () {
    angular.module('SquareRoute')
        .controller('LoginController', LoginController)
        .controller('LogoffController',LogoffController)

    function LoginController(loginService, $location) {
        var vm = this;
        vm.message = "Login View";

        vm.login = function () {
            loginService.login(vm.username, vm.password).then(loginSuccess, loginFail);
        }
        function loginSuccess() {
            $location.path('/');
        }
        function loginFail(data) {
            console.log(data);
        }
    }

    function LogoffController(loginService, $location) {

        
        loginService.logoff().then(logoffSuccess, logoffFail);
                
        function logoffSuccess() {
            $location.path('/');
        }
        function logoffFail(data) {
            console.log(data);
        }
    }

})();