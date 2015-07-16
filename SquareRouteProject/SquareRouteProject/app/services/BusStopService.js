'use strict';
(function () {
    angular.module('SquareRoute')
        .factory('busStopService', busStopService)


    function busStopService($http, $q, $window) {

        var bustops = [];

        var token = $window.sessionStorage.getItem('token');
        
        var busStopService = {};
        busStopService.getAllBusStops = getAllBusStops;
        busStopService.getBusStopById = getBusStopById;
        busStopService.getBusStopsByRouteId = getBusStopsByRouteId;
        busStopService.addBusStop = addBusStop;
        busStopService.updateBusStop = updateBusStop;
        busStopService.deleteBusStopById = deleteBusStopById;

        //GET all BusStops
        function getAllBusStops() {
            var deferred = $q.defer();
            $http({
                url: '/api/BusStop/GetAllBusStops',
                method: 'GET'
                //headers: { 'Authorization': 'Bearer' + token }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET BusStop by Id
        function getBusStopById(id) {
            var deferred = $q.defer();
            $http({
                url: 'api/BusStop/GetBusStopById/'+ id,
                method: 'GET'                
                //headers: { 'Authorization': 'Bearer' + token }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET BusStop by RouteId
        function getBusStopsByRouteId(id) {
            var deferred = $q.defer();
            $http({
                url: '/api/BusStop/GetBusStopsbyRouteId/' + id,
                method: 'GET'                
                //headers:{'Authorization':'Bearer'+token}
            })
            .success(function (data) {                
                deferred.resolve(data);                
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //Post Add BusStop
        function addBusStop(busStop) {
            var deferred = $q.defer();
            $http({
                url: '/api/BusStop/AddBusStop',
                method: 'POST',
                data: busStop
                //headers: { 'Authorization': 'Bearer' + token }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //Post Update BusStop
        function updateBusStop(busStop) {
            var deferred = $q.defer();
            $http({
                url: '/api/BusStop/UpdateBusStop',
                method: 'POST',
                data: busStop
                //headers: { 'Authorization': 'Bearer' + token }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //Post Delete BusStop by Id
        function deleteBusStopById(id) {
            var deferred = $q.defer();
            $http({
                url: '/api/BusStop/DeleteBusStopById/' + id,
                method: 'DELETE'
                //headers: { 'Authorization': 'Bearer' + token }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }
        return busStopService;
    }
})();