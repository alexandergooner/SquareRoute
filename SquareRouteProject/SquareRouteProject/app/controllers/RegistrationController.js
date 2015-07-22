(function () {
    angular.module('SquareRoute')
        .controller('RegistrationController', RegistrationController)

    function RegistrationController($location, userService) {
        var vm = this;
        vm.message = "Registration View";

        vm.register = function () {

            var userToRegister = {
                Email: vm.email,
                Password: vm.createPassword,
                ConfirmPassword: vm.confirmPassword,
                FirstName: vm.firstName,
                LastName: vm.lastName,
                ImageUrl: vm.imageUrl,
                MobileDeviceId: vm.mobileDeviceId,
                Address: vm.addressLine1 + ' ' + vm.addressLine2,
                City: vm.city,
                State: vm.state,
                PostalCode: vm.postalCode,
                //RoleType: 1                
            };

            userService.registerUser(userToRegister).then(registerSuccess, registerFail);            
        }

        function registerSuccess() {
            $location.path('/');
        }
        function registerFail(data) {
            console.log(data);
        }
    }
})();