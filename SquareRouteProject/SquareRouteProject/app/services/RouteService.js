'use strict';
(function () {
    angular.module('SquareRoute')
        .factory('routeService', routeService);

    // ROUTE SERVICE
    function routeService($http, $q, $window) {
        var routeService = {};

        routeService.getRouteById = getRouteById;
        routeService.getRouteByRouteNum = getRouteByRouteNum;
        routeService.getRoutesByDistrictId = getRoutesByDistrictId;
        routeService.getAllRoutes = getAllRoutes;
        routeService.addRoute = addRoute;
        routeService.updateRoute = updateRoute;
        routeService.deleteRouteById = deleteRouteById

        // GET by RouteId
        function getRouteById(id) {
            var deferred = $q.defer();            
            http.get({
                url: '/api/Route/GetRouteById',
                data: id
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET by RouteNum
        function getRouteByRouteNum(routeNum) {
            var deferred = $q.defer();        
            $http.get({
                url: '/api/Route/GetRouteByRouteNum',
                data: routeNum
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise();
        }

        //GET by DistrictId
        function getRoutesByDistrictId(districtId) {
            var deferred = $q.defer();
            $http.get({
                url: '/api/Route/GetRoutesByDistrictId',
                data: districtId
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise();
        }

        //GET all Routes
        function getAllRoutes() {
            var deferred = $q.defer();
            $http.get({
                url: '/api/Route/GetAllRoutes',
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise();
        }
            
        //ADD Route
        function addRoute(route) {
            var deferred = $q.defer();            
            http.post({
                url: '/api/Route/AddRoute',
                data: route
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }
        
        //UPDATE Route
        function updateRoute(route) {
            var deferred = $q.defer();
            http.post({
                url: '/api/Route/UpdateRoute',
                data: route
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //DELETE Route
        function deleteRouteById(id) {
            var deferred = $q.defer();
            $http.post({
                url: '/api/Route/DeleteRouteById',
                data: id
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        return routeService;
    }
})();