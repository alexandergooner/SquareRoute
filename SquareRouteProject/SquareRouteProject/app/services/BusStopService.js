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
            $http.get({
                url: 'api/BusStop/GetAllBusStops'
                //headers: { 'Authorization': 'Bearer' + token }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return intialDeferred.promise;
        }

        //GET BusStop by Id
        function getBusStopById(id) {
            var deffered = $q.defer();
            $http.get({
                url: 'api/BusStop/GetBusStopById',
                data: id
                //headers: { 'Authorization': 'Bearer' + token }
            }).success(function (data) {
                console.log(data);
                deffered.resolve(data);
            }).error(function (data) {
                deffered.reject(data);
            });
            return deffered.promise;
        }

        //GET BusStop by RouteId
        function getBusStopsByRouteId(id) {
            var deferred = $q.defer();
            $http.get({
                url: 'api/BusStop/GetBusStopsbyRouteId',
                data: id
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
                url: 'api/BusStop/AddBusStop',
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
        function updateBusStop(bustop) {
            var deferred = $q.defer();
            $http({
                url: 'api/BusStop/UpdateBusStop',
                method: 'POST',
                data: bustop
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
                url: 'api/BusStop/DeleteBusStopById',
                method: 'POST',
                data: id
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