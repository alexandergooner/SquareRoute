'use strict';
(function () {
    angular.module('SquareRoute')
        .factory('routeSchoolService', routeSchoolService);

    //ROUTESCHOOL SERVICE
    function routeSchoolService($http, $q, $window) {
        var routeSchoolService = {};

        routeSchoolService.addRouteSchool = addRouteSchool;
        routeSchoolService.getAllRouteSchoolsByRouteId = getAllRouteSchoolsByRouteId;
        routeSchoolService.getAllRouteSchoolsBySchoolId = getAllRouteSchoolsBySchoolId;
        routeSchoolService.updateRouteSchool = updateRouteSchool;
        routeSchoolService.deleteRouteSchool = deleteRouteSchool;

        //POST add RouteSchool
        function addRouteSchool(routeSchool) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteSchool/AddRouteSchool',
                method: 'POST',
                data: routeSchool
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET all RouteSchools by RouteId
        function getAllRouteSchoolsByRouteId(routeId) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteSchool/GetAllRouteSchoolsByRouteId/' + routeId,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //GET all RouteSchools by SchoolId
        function getAllRouteSchoolsBySchoolId(schoolId) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteSchool/GetAllRouteSchoolsBySchoolId/' + schoolId,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //POST update RouteSchool
        function updateRouteSchool(routeSchool) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteSchool/UpdateRouteSchool',
                method: 'POST',
                data: routeSchool
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //DELETE RouteSchool
        function deleteRouteSchool(routeSchool) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteSchool/DeleteRouteSchool',
                method: 'POST',
                data: routeSchool
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        return routeSchoolService;
    }
})();