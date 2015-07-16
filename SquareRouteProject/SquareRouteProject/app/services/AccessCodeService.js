'use strict';
(function () {
    angular.module('SquareRoute')
        .factory('accessCodeService', accessCodeService);

    function accessCodeService($http, $q, $window) {
        var accessCodeService = {};

        accessCodeService.getAllAccessCodes = getAllAccessCodes;
        accessCodeService.addAccessCode = addAccessCode;
        accessCodeService.getAccessCodeById = getAccessCodeById;
        accessCodeService.getAccessCodeByValue = getAccessCodeByValue;
        accessCodeService.getAccessCodeByRouteId = getAccessCodeByRouteId;
        accessCodeService.updateAccessCode = updateAccessCode;
        accessCodeService.deleteAccessCodeById = deleteAccessCodeById;

        var accessCodes = [];

        var token = $window.sessionStorage.getItem('token');
        
        //GET all AccessCodes
        function getAllAccessCodes() {
            var deferred = $q.defer();
            $http({                
                url: '/api/AccessCode/GetAllAccessCodes',
                method: 'GET'
                //headers:{'Authenication':'Bearer'+token}
            }).success(function (data) {                
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET AccessCode by RouteId
        function getAccessCodeByRouteId(id) {
            var deferred = $q.defer();
            $http({                
                url: '/api/AccessCode/GetAccessCodeByRouteId/' + id,
                method: 'GET'
                //header:{}
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //GET AccessCode by Id
        function getAccessCodeById(id) {
            var deferred = $q.defer();
            $http({
                url: '/api/AccessCode/GetAccessCodeById/' + id,
                method: 'GET'
                //header:{''}
            }).success(function (data) {
                console.log(data)                
                deferred.resolve(data)
            }).error(function (data) {
                deferred.reject(data)
            })
            return deferred.promise;
        }

        //Get AccessCode by CodeValue
        function getAccessCodeByValue(accessCodeValue) {
            var deferred = $q.defer();
            $http({                
                url: '/api/AccessCode/GetAccessCodeByValue/' + accessCodeValue,
                method: 'GET'
                //header:{}
            }).success(function (data) {                
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //POST add AccessCode
        function addAccessCode(accessCode) {
            var deferred = $q.defer();
            $http({                
                url: '/api/AccessCode/AddAccessCode',
                method: 'POST',
                data: accessCode
                //header: {},
            }).success(function (data) {               
                deferred.resolve(data)
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //Post update AccessCode
        function updateAccessCode(accessCode) {
            var deferred = $q.defer();
            $http({                
                url: '/api/AccessCode/UpdateAccessCode',
                method: 'POST',
                data: accessCode
                //header:{}
            }).success(function (data) {              
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //Post delete AccessCode by Id
        function deleteAccessCodeById(id) {
            var deferred = $q.defer();
            $http({
                url: '/api/AccessCode/DeleteAccessCodeById/' + id,
                method: 'DELETE',
                //header:{}
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        return accessCodeService;
    }
})();