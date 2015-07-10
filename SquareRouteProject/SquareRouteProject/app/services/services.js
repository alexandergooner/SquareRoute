(function () {
    angular.module("SquareRoute")
        .factory('loginService', loginService)
        .factory('registerService', registerService);

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

    // REGISTER SERVICE
    function registerService($http, $q, $window) {
        var service = {};

        service.register = register;

        function register(email, password, passwordConfirm, roleType) {
            var deffered = $q.defer();
            var data = {
                Email: email,
                Password: password,
                ConfirmPassword: passwordConfirm,
                RoleType: roleType
            };

            $http({
                url: '/api/Account/Register',
                method: 'POST',
                data: data
                //headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (data) {
                //$window.sessionStorage.setItem('token', data.access_token);
                deferred.resolve();
            }).error(function (data) {
                deferred.reject();
            });

            return deferred.promise;
        }

        return service;
    }
})();