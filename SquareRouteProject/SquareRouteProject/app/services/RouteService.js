(function () {
    angular.module('SquareRoute')
        .factory('routeService', routeService);

    // ROUTE SERVICE
    function routeService($http, $q, $window) {
        var service = {};

        service.getRouteById = getRouteById;
        service.getRouteByRouteNum = getRouteByRouteNum;
        service.getRoutesByDistrictId = getRoutesByDistrictId;
        service.getAllRoutes = getAllRoutes;
        service.addRoute = addRoute;
        service.updateRoute = updateRoute;
        service.deleteRouteById = deleteRouteById

        // GET by RouteId
        function getRouteById(id) {
            var deferred = $q.defer();
            var data = {
                RouteId: id
            };

            http.get({
                url: '/api/Route/GetRouteById',
                data: data
                //headers:
            }).success(function (data) {
                deferred.resolve();
            }).error(function (data) {
                deferred.reject();
            });

            return deferred.promise;
        }

        //GET by RouteNum
        function getRouteByRouteNum(routeNum) {
            var deferred = $q.defer();
            var data = {
                RouteNum: routeNum
            }

            $http.get({
                url: '/api/Route/GetRouteByRouteNum',
                data: data
                //headers
            }).success(function (data) {
                deferred.resolve();
            }).error(function (data) {
                deferred.reject();
            });

            return deferred.promise();
        }

        //GET by DistrictId
        function getRoutesByDistrictId(districtId) {
            var deferred = $q.defer();
            var data = {
                DistrictId: districtId
            }

            $http.get({
                url: '/api/Route/GetRoutesByDistrictId',
                data: data
                //headers
            }).success(function (data) {
                deferred.resolve();
            }).error(function (data) {
                deferred.reject();
            })

            return deferred.promise();
        }

        //GET all Routes
        function getAllRoutes() {
            var deferred = $q.defer();

            $http.get({
                url: '/api/Route/GetAllRoutes',
                //headers:
            }).success(function () {
                deferred.resolve();
            }).error(function () {
                deferred.reject();
            });

            return deferred.promise();
        }
            

        //ADD Route
        function addRoute(routeId, routeNum, routeStart, routeEnd, accessCodeId, districtId) {
            var deferred = $q.defer();
            var data = {
                RouteId: routeId,
                RouteNum: routeNum,
                RouteStart: routeStart,
                RouteEnd: routeEnd,
                AccessCodeId: accessCodeId,
                DistrictId: districtId
            };

            http.post({
                url: '/api/Route/AddRoute',
                data: data
                //headers:
            }).success(function (data) {
                deferred.resolve();
            }).error(function (data) {
                deferred.reject();
            });

            return deferred.promise;
        }
        
        //UPDATE Route
        function updateRoute(routeId, routeNum, routeStart, routeEnd, accessCodeId, districtId) {
            var deferred = $q.defer();
            var data = {
                RouteNum: routeNum,
                RouteStart: routeStart,
                RouteEnd: routeEnd,
                AccessCodeId: accessCodeId,
                DistrictId: districtId
            };

            http.post({
                url: '/api/Route/UpdateRoute',
                data: data
                //headers:
            }).success(function (data) {
                deferred.resolve();
            }).error(function (data) {
                deferred.reject();
            });

            return deferred.promise;
        }

        //DELETE Route
        function deleteRouteById(id) {
            var deferred = $q.defer();
            var data = {
                RouteId: id
            }

            $http.post({
                url: '/api/Route/DeleteRouteById',
                data: data
                //headers:
            }).success(function (data) {
                deferred.resolve();
            }).error(function (data) {
                deferred.reject();
            });

            return deferred.promise;
        }
    }
})();