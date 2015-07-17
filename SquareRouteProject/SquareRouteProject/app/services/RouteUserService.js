'use strict';
(function () {
    angular.module('SquareRoute')
        .factory('routeUserService', routeUserService);

    function routeUserService($http, $q, $window) {
        var routeUserService = {};

        routeUserService.addRouteUser = addRouteUser;
        routeUserService.getAllRouteUsersByUserId = getAllRouteUsersByUserId;
        routeUserService.getAllRouteUsersByUsername = getAllRouteUsersByUsername;
        routeUserService.updateRouteUser = updateRouteUser;
        routeUserService.deleteRouteUser = deleteRouteUser;

        //POST add RouteUser
        function addRouteUser(routeUser) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteUser/AddRouteUser',
                method: 'POST',
                data: routeUser
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET all RouteUsers by UserId
        function getAllRouteUsersByUserId(userId) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteUser/GetAllRouteUsersByUserId/' + userId,
                method: 'GET'
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET all RouteUsers by username 
        function getAllRouteUsersByUsername(username) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteUser/GetAllRouteUsersByUsername/' + username,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //POST update RouteUser
        function updateRouteUser(routeUser) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteUser/UpdateRouteUser',
                method: 'POST',
                data: routeUser
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //DELETE a RouteUser
        function deleteRouteUser(routeUser) {
            var deferred = $q.defer();
            $http({
                url: '/api/RouteUser/DeleteRouteUser',
                method: 'DELETE',
                data: routeUser
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        return routeUserService;
    }
})();