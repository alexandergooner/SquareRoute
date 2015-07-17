'user strict';
(function () {
    angular.module('SquareRoute')
    .factory('accessCodeUserService', accessCodeUserService);

    // ACCESSCODEUSER SERVICE
    function accessCodeUserService($http, $q, $window) {
        var accessCodeUserService = {};

        accessCodeUserService.addAccessCodeUser = addAccessCodeUser;
        accessCodeUserService.getAllAccessCodeUsersByUserId = getAllAccessCodeUsersByUserId;
        accessCodeUserService.getAllAccessCodeUsersByAccessCodeId = getAllAccessCodeUsersByAccessCodeId;
        accessCodeUserService.updateAccessCodeUser = updateAccessCodeUser;
        accessCodeUserService.deleteAccessCodeUser = deleteAccessCodeUser;

        //POST add AccessCodeUser
        function addAccessCodeUser(accessCodeUser) {
            var deferred = $q.defer();
            $http({
                url: '/api/AccessCodeUser/AddAccessCodeUser',
                method: 'POST',
                data: accessCodeUser
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET all AccessCodeUsers by UserId
        function getAllAccessCodeUsersByUserId(userId) {
            var deferred = $q.defer();
            $http({
                url: '/api/AccessCodeUser/getAllAccessCodeUsersByUserId/' + userId,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //GET all AccessCodeUsers by AccessCodeId
        function getAllAccessCodeUsersByAccessCodeId(accessCodeId) {
            var deferred = $q.defer();
            $http({
                url: '/api/AccessCodeUser/getAllAccessCodeUsersByAccessCodeId/' + accessCodeId,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //POST update AccessCodeUser
        function updateAccessCodeUser(accessCodeUser) {
            var deferred = $q.defer();
            $http({
                url: '/api/AccessCodeUser/UpdateAccessCodeUser',
                method: 'POST',
                data: accessCodeUser
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //DELETE AccessCodeUser
        function deleteAccessCodeUser(accessCodeUser) {
            var deferred = $q.defer();
            $http({
                url: '/api/AccessCodeUser/DeleteAccessCodeUser',
                method: 'DELETE',
                data: accessCodeUser
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        return accessCodeUserService;
    }
})();