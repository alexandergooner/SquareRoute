(function () {
    angular.module('SquareRoute')
        .controller('AdminController', AdminController)

    function AdminController() {
        var vm = this;
        vm.message = "Admin View";
    }
})();