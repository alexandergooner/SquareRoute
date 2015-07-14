'use strict';
(function () {
    angular.module('SquareRoute')
        .factory('accessCodeService', accessCodeService);


    function accessCodeService($http, $q, $window) {

        accessCodeService = {};
        accessCodeService.getAllAccessCodes = getAllAccessCodes;
        accessCodeService.addAccessCode = addAccessCode;
        accessCodeService.getAccessCodeById = getAccessCodeById;
        accessCodeService.getAccessCodeByName = getAccessCodeByName;
        accessCodeService.getAccessCodeByRouteId = getAccessCodeByRouteId;
        accessCodeService.updateAccessCode = updateAccessCode;
        accessCodeService.deleteAccessCode = deleteAccessCodeById;

        var accesCodes = [];

        var token = $window.sessionStorage.getItem('token');
        
        //GET all AccessCodes
        function getAllAccessCodes() {
            var deferred = $q.defer;
            $http.get({
                url: 'api/AccessCode/GetAllAccessCodes'
                //headers:{'Authenication':'Bearer'+token}
            }).sucess(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise();
        }

        //GET AccessCode by RouteId
        function getAccessCodeByRouteId(id) {
            var deferred = $q.defer;
            $http.get({
                url: 'api/AccessCode/GetAccessCodeByRouteId',
                data: id
                //header:{}
            }).sucess(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //GET AccessCode by Id
        function getAccessCodeById(id) {
            var deferred = $q.defer;
            $http.get({
                url: ' api/AccessCode/GetAccessCodeById',
                data: id
                //header:{''}
            }).sucess(function (data) {
                console.log(data)                
                deferred.resolve(data)
            }).error(function (data) {
                deferred.reject(data)
            })
            return deferred.promise;
        }

        //Get AccessCode by CodeValue
        function getAccessCodeByName(accessCodeValue) {
            var deferred = $q.defer;
            $http.get({
                url: 'api/AccessCode/GetAccessCodeByValue',
                data: accessCodeName
                //header:{}
            }).sucess(function (data) {                
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        //POST add AccessCode
        function addAccessCode(accessCode) {
            var deferred = $q.defer;
            $http.post({
                url: 'api/AccessCode/AddAccessCode',                
                data: accessCode
                //header: {},
            }).success(function () {
                accesCodes.push(accessCode)
                deferred.resolve()
            }).error(function () {
                deferred.reject();
            })
            return deferred.promise;
        }

        //Post update AccessCode
        function updateAccessCode(accessCode) {
            var deferred = $q.defer;
            $http.post({
                url: 'api/AccessCode/UpdateAccessCode',
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
            var deferred = $q.defer;
            $http({
                url: ' api/AccessCode/DeleteAccessCodeById',
                method: 'POST',
                data: id
                //header:{}
            }).sucess(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        return accessCodeService;
    }
})();