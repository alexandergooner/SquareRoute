(function () {
    angular.module("SquareRoute")
        .factory('registerService', registerService);

    // REGISTER SERVICE
    function registerService($http, $q, $window) {
        var service = {};

        service.register = register;

        function register(userToRegister) {
            var deffered = $q.defer();

            $http({
                url: '/api/Account/Register',
                method: 'POST',
                data: userToRegister
                //headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (data) {
                //$window.sessionStorage.setItem('token', data.access_token);
                deferred.resolve();
            }).error(function (data) {
                deferred.reject(data);
            });

            return deferred.promise;
        }

        return service;
    }
})();