(function () {
    angular.module('SquareRoute')
        .factory('emailService', emailService)

    function emailService($http, $q, $window) {
        var token = $window.sessionStorage.getItem('token');

        var emailService = {}
        emailService.sendEmail = sendEmail;

        function sendEmail(email) {
            var deferred = $q.defer();
            $http({
                url: 'api/Email/SendEmail',
                method: 'POST',
                data: email
                //headers : { 'Authorization': 'Bearer ' + token }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            })
            return deferred.promise;
        }

        return emailService;
    }
})();