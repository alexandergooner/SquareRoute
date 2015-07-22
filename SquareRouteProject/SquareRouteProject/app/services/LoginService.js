(function () {
    angular.module('SquareRoute')
        .factory('loginService', loginService)

    function loginService($http, $q, $window) {
        var service = {};

        service.login = login;
        service.logoff = logoff;

        function login(username, password) {
            var deferred = $q.defer();

            $http({
                url: '/Token',
                method: 'POST',
                data: 'username=' + username + '&password=' + password + '&grant_type=password',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (data) {
                $window.sessionStorage.setItem('token', data.access_token);
                deferred.resolve();
            }).error(function (data) {
                deferred.reject(data);
            });

            return deferred.promise;
        }

        function logoff() {
            var deferred = $q.defer();

            $http({
                url: '/api/Account/Logout',
                method: 'POST',                                
            }).success(function (data) {                
                deferred.resolve();
            }).error(function (data) {
                deferred.reject(data);
            });

            return deferred.promise;
        }

        return service;
    }

})();