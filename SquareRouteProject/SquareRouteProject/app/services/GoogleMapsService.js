(function () {
    angular.module('SquareRoute')
        .factory('googleMapsService', googleMapsService)

    function googleMapsService($http, $q, $window) {
        var service = {};

        service.getRoutes = getRoutes;
        

        function getRoutes() {
            var deferred = $q.defer();
            $http({
                url: '/api/busroutes',
                method: 'GET'
            }).success(function (data) {
                console.log(data);

                deferred.resolve();

            }).error(function () {
                console.log("ERROR");

                deferred.reject();
            });

            return deferred.promise;
        };

        function initialize() {

        }

        return service;
    }

   

})();