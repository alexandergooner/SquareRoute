(function () {
    angular.module('SquareRoute')
        .controller('DispatcherController', DispatcherController)

    function DispatcherController() {
        var vm = this;
        vm.message = "Dispatcher View";
    }
})();