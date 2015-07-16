(function () {
    angular.module('SquareRoute')
        .controller('EmailController', EmailController);

    function EmailController(emailService) {
        var vm = this;
        vm.message = "Email View";

        vm.sendEmail = function () {
            vm.input = {
                To: vm.emailTo,
                Subject: vm.emailSubject,
                Body: vm.emailBody
            };

            emailService.sendEmail(vm.input).then(callSuccess, callFail);
        }

        function callSuccess(data) {
            vm.result = data;
            console.log("Success");
            console.log(data);
        }
        function callFail(data) {
            console.log("Failed");
            console.log(data);
        }
    }
})();