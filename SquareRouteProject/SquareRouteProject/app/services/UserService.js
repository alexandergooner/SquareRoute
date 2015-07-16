(function () {
    angular.module('SquareRoute')
        .factory('userService', userService);

    //USER SERVICE
    function userService($http, $q, $window) {

        var userService = {};
        userService.addUser = addUser;
        userService.getUserByEmail = getUserByEmail;
        userService.getUsersByRoleType = getUsersByRoleType;
        userService.updateUser = updateUser;
        userService.deleteUser = deleteUser;

        //POST add User
        function addUser(user) {
            var deferred = $q.defer();
            $http({
                url: '/api/Account/Register',
                method: 'POST',
                data: user
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET User by email
        function getUserByEmail(email) {
            var deferred = $q.defer();
            $http({
                url: '/api/Account/GetUserByEmail/' + email,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //GET Users by Type
        function getUsersByRoleType(roleType) {
            var deferred = $q.defer();
            $http({
                url: '/api/Account/GetUsersByRoleType/' + roleType,
                method: 'GET'
                //headers
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //POST update User
        function updateUser(user) {
            var deferred = $q.defer();
            $http({
                url: '/api/Account/UpdateUser',
                method: 'POST',
                data: user
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        //DELETE User
        function deleteUser(user) {
            var deferred = $q.defer();
            $http({
                url: '/api/Account/DeleteUser',
                method: 'DELETE',
                data: user
                //headers:
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

        return userService;
    }
})();