(function () {

    angular.module('SquareRoute').factory('modalService', modalService)



    function modalService(busStopService) {

        var service = {}
        service.updateBusStop = busStopService.updateBusStop;







        return service;

    }











})();
