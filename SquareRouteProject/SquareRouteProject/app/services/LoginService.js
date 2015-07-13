(function () {
    angular.module("SquareRoute")
        .factory('loginService', loginService);        

    // LOGIN SERVICE
    function loginService($http, $q, $window) {
        var service = {};

        service.login = login;

        function login(username, password) {
            var deffered = $q.defer();

            $http({
                url: '/Token',
                method: 'POST',
                data: 'username=' + username + '&password=' + password + '&grant_type=password',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (data) {
                $window.sessionStorage.setItem('token', data.access_token);
                deferred.resolve();
            }).error(function () {
                deferred.reject();
            });

            return deferred.promise;
        }

        return service;
    }
})();