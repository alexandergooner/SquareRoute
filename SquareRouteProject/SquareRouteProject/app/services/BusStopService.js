'use strict';

(function () {
    angular.module('SquareRoute').factory('busStopService', busStopService)


    function busstopService($http, $q, $window) {

        var bustops = [];

        var token = $window.sessionStorage.getItem('token');

        var intialDeferred = $q.defer();


        var busService = {};
        busService.getAllBusStops = getAllBusStops;
        busService.getBusStopById = getBusStopById;
        busService.getBusStopByRouteId = getBusStopByRouteId;
        busService.addBusStop = addBusStop;

        function getAllBusStops() {
            $http.get({
                url: 'api/BusStop/GetAllBusStops',

                //headers: { 'Authorization': 'Bearer' + token }
            }).sucess(function (data) {

                intialDefered.reslove(data)
            }).error(function () {
                intialDefered.reject();
            });
            return intialDeferred.promise;
        }
        function getBusStopById(id) {
            var deffered = $q.defer();
            $http.get({
                url: 'api/BusStop/GetBusStopById',

                data: id,
                //headers: { 'Authorization': 'Bearer' + token }
            }).sucess(function (data) {
                console.log(data);
                for (var i in data) {
                    bustops.push(data[i])

                }
                deffered.reslove(bustops)

            }).erro(function () {
                deffered.reject
            })

            return deffered.promise;

        }

        function getBusStopsByRouteId(id) {
            var deferred = $q.defer();
            $http.get({
                url: 'api/BusStop/GetBusStopsbyRouteId',

                data: id,
                //headers:{'Authorization':'Bearer'+token}
            })
            .sucess(function (data) {
                if (data) {
                    for (var i in data) {
                        bustops.push(data[i])
                    }
                    deferred.reslove(bustops);

                }
            }).error(function () {
                deferred.reject();
            })
            return deferred.promise;

        }

        function AddBusStop(bustop) {

            var deferred = $q.defer();
            $http({
                url: 'api/BusStop/AddBusStop',
                method: 'POST',
                data: bustop,
                headers: { 'Authorization': 'Bearer' + token }
            }).sucess(function (data) {

                if (data) {
                    bustops.push(bustop)
                }
                deferred.reslove();
            }).error(function () {
                deferred.reject();
            })
            return deferred.promise;
        }



        return busService;

    }










})();