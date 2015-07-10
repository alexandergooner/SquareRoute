(function () {
    angular.module('SquareRoute')
        .controller('WelcomeController', WelcomeController)

    function WelcomeController() {
        var vm = this;
        vm.message = "Welcome view";
    }
})();