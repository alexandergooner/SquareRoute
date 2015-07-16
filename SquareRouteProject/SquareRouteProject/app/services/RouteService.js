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
            $http({                
                url: '/api/Route/GetRouteById/' + id,
                method: 'GET'
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
            $http({               
                url: '/api/Route/GetRouteByRouteNum/' + routeNum,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET by DistrictId
        function getRoutesByDistrictId(districtId) {
            var deferred = $q.defer();
            $http({                
                url: '/api/Route/GetRoutesByDistrictId/' + districtId,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //GET all Routes
        function getAllRoutes() {
            var deferred = $q.defer();
            $http({                
                url: '/api/Route/GetAllRoutes',
                method: 'GET'
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }
            
        //POST add Route
        function addRoute(route) {
            var deferred = $q.defer();            
            $http({               
                url: '/api/Route/AddRoute',
                method: 'POST',
                data: route
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }
        
        //POST update Route
        function updateRoute(route) {
            var deferred = $q.defer();
            $http({                
                url: '/api/Route/UpdateRoute',
                method: 'POST',
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
            $http({               
                url: '/api/Route/DeleteRouteById',
                method: 'DELETE',
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