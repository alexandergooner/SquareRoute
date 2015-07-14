(function () {
    angular.module('SquareRoute').factory('accessCodeService', accessCodeService);


    function accessCodeService($http, $q, $window) {

        accessCodeService = {};
        accessCodeService.getAllAccessCodes = getAllAccessCodes;
        accessCodeService.addAccessCode = addAccessCode;
        accessCodeService.getAccessCodeById = getAccessCodeById;
        accessCodeService.getAccessCodeByName = getAccessCodeByName;
        accessCodeService.getAccessCodeByRouteId = getAccessCodeByRouteId;
        accessCodeService.updateAccessCode = updateAccessCode;
        accessCodeService.deleteAccessCode = deleteAccessCode;


        var intialDeferred = $q.defer;

        var accesCodes = [];

        var token = $window.sessionStorage.getItem('token');
        function getAllAccessCodes() {
            $http.get({
                url: 'api/AccessCode/GetAllAccessCodes',
                //headers:{'Authenication':'Bearer'+token}
            }).sucess(function (data) {
                intialDeferred.resolve(data);
            }).error(function () {
                intialDeferred.reject();
            })
            return intialDeferred.promise();


        }


        function getAccessCodeByRouteId(id) {
            var defer = $q.defer;

            $http.get({
                url: 'api/AccessCode/GetAccessCodeByRouteId',
                data: id,
                //header:{}
            }).sucess(function (data) {
                if (data) {
                    for (var i in data) {
                        accesCodes.push(data[i])
                    }
                    defer.resolve(accesCodes);
                }


            }).error(function () {
                defer.reject();
            })
            return defer.promise;



        }

        function getAccessCodeById(id) {

            var defer = $q.defer;

            $http.get({
                url: ' api/AccessCode/GetAccessCodeById',
                data: id,
                //header:{''}
            }).sucess(function (data) {
                console.log(data)
                for (var i in data) {
                    accesCodes.push(data[i])
                }
                defer.resolve(accesCodes)
            }).error(function () {
                defer.reject()

            })
        }

        function getAccessCodeByName(accessCodeName) {
            var defer = $q.defer;

            $http.get({
                url: 'api/AccessCode/GetAccessCodeByName',
                data: accessCodeName,
                //header:{}
            }).sucess(function (data) {

                for (var i in data) {
                    accesCodes.push(data[i])
                }
                defer.resolve(accesCodes);
            }).error(function () { defer.reject(); })
            return defer.promise;
        }


        function addAccessCode(accessCode) {
            var defer = $q.defer;

            $http.post({
                url: 'api/AccessCode/AddAccessCode',
                header: {},
                data: accesCode
            }).sucess(function () {
                accesCodes.push(accessCode)
                defer.resolve()

            }).error(function () {
                defer.reject();
            })


            return defer.promise;

        }

        function updateAccessCode(accessCode) {

            var defer = $q.defer;

            $http.post({
                url: 'api/AccessCode/UpdateAccessCode',
                data: accessCode,
                //header:{}
            }).success(function (data) {
                if (data) {
                    accesCodes.push(data[i])
                }
                defer.resolve(accesCodes);
            }).error(function () {
                defer.reject();
            })

            return defer.promise;
        }


        function deleteAccessCodeById(id) {

            var defer = $q.defer;

            $http({
                url: ' api/AccessCode/DeleteAccessCodeById',
                method: 'POST',
                data: id,
                //header:{}
            }).sucess(function () {
                defer.resolve();
            }).error(function () { defer.reject(); })



        }

        return accessCodeService;
    }
})();