(function () {
    angular.module("SquareRoute")
        .factory('loginService', loginService).factory('AuthService',AuthService).constant('USER_Roles', { all:'*',admin:'admin',editor:'editor',guest:'guest'}).constant('AUTH_EVENTS',{ loginSucces:'auth-login-sucess',loginFailed:'auth-login-failed ', logoutSucess:'auth-login-sucess', sessionTimeout:'auth-session-timeout', notAuthenticated:'auth-not-authenticated', notAuthorized:'auth-not-authorized'})

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


    function AuthService($http, $window,$location) {

        var authServiceFactory = {};

        var _authenticaiton = {
            isAuth:false,
            userName:""
        };

        authServiceFactory.saveRegistration = function(registration){
            authServiceFactory.logout();
            return $http.post('/Token'+'api/account/register',registration).then(function(response){return response});
        }

        authServiceFactory.login = function (loginData) {
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
            var deffered = $q.defer();
            
            $http.post($location + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .Sucess(function(data){
                    $window.sessionStorage.setItem('token',data.access_token)
                    _authenication.isAuth= true; 
                    _authenication.username = loginData.username;
                    deffered.resolve(data)

                }).error(function(err,status){
                    authServiceFactory.logOut();
                    deffered.reject(err);
                })

            return deffered.promise;

            //authService.isAuthenticated = function(authorizedRoles){
            //    if (!angular.isArray(authorizedRoles)){
            //        authorizedRoles = [authorizedRoles];
            //    }
            //    return (authService.isAuthenticated()&& authorizedRoles.indexOf())
            //}
        

        };

        authServiceFactory.logOut= function(){
            _authenticaiton.isAuth= false;
            _authenticaiton.userName= "";

        }

        authServiceFactory.fillAuthData = function(){
            var authData = $window.get('token');
            _authenticaiton.isAuth = false; 
            _authenticaiton.userName = "";

        };

       
        return authServiceFactory;

        }

   
})();