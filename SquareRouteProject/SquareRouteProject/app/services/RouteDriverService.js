'use strict';
(function () {
    angular.module('SquareRoute')
        .factory('routeDriverService', routeDriverService);

    // ROUTEDRIVER SERVICE
    function routeDriverService($http, $q, $window) {
        var routeDriverService = {};

        routeDriverService.addRouteDriver = addRouteDriver;
        routeDriverService.getRouteDriverByUserId = getRouteDriverByUserId;
        routeDriverService.getRouteDriverByRouteId = getRouteDriverByRouteId;
        routeDriverService.updateRouteDriver = updateRouteDriver;
        routeDriverService.deleteRouteDriver = deleteRouteDriver;

        //POST add RouteDriver
        function addRouteDriver(routeDriver) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteDriver/AddRouteDriver',
                method: 'POST',
                data: routeDriver
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET RouteDriver by UserId 
        function getRouteDriverByUserId(userId) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteDriver/GetRouteDriverByUserId/' + userId,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //GET RouteDriver by RouteId
        function getRouteDriverByRouteId(routeId) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteDriver/GetRouteDriverByRouteId/' + routeId,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //POST update RouteDriver
        function updateRouteDriver(routeDriver) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteDriver/UpdateRouteDriver',
                method: 'POST',
                data: routeDriver
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //DELETE RouteDriver
        function deleteRouteDriver(routeDriver) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteDriver/DeleteRouteDriver',
                method: 'DELETE',
                data: routeDriver
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        return routeDriverService;
    }
})();