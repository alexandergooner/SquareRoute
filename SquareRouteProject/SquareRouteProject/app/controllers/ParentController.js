(function () {
    angular.module('SquareRoute')
        .controller('ParentController', ParentController)

    function ParentController() {
        var vm = this;
        vm.message = "Parent View";
    }
})();