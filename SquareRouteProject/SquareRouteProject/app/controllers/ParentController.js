(function () {
    angular.module('SquareRoute')
        .controller('ParentController', ParentController)

    function ParentController() {
        var vm = this;
        vm.message = "Parent View";

        vm.map = {
            center: {
                latitude: 29.758943,
                longitude: -95.361720
            },
            zoom: 10,
        }

    }

})();