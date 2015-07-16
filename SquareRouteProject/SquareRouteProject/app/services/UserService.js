(function () {
    angular.module('SquareRoute')
        .factory('userService', userService);

    //USER SERVICE
    function userService($http, $q, $window) {

        var userService = {};
        userService.registerUser = registerUser;
        userService.getUserByEmail = getUserByEmail;
        userService.getUsersByRoleType = getUsersByRoleType;
        userService.getAllUsers = getAllUsers;
        userService.updateUser = updateUser;
        userService.deleteUser = deleteUser;

        //POST add User
        function registerUser(user) {
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
            var data = new String(email);
            for (var i = 0; i < 5;i++) {
                data = new String(data).replace('.', '@@');
            }
            
            $http({
                url: '/api/Account/GetUserByEmail/' + data,
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

        //GET all Users
        function getAllUsers() {
            var deferred = $q.defer();
            $http({
                url: '/api/Account/GetAllUsers',
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