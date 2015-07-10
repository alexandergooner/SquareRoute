(function () {
    angular.module('SquareRoute')
        .controller('LoginController', LoginController)

    function LoginController() {
        var vm = this;
        vm.message = "Login View";
    }
})();