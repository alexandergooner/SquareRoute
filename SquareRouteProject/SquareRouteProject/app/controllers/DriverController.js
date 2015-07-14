(function () {
    angular.module('SquareRoute')
        .controller('DriverController', DriverController)

    function DriverController () {
        var vm = this;
        vm.message = "Driver View";
    }
})();