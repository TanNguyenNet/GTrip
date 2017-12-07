(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', '$scope', '$window', 'apiService'];

    function rootController($state, $scope, $window, apiService) {

        $scope.authentication = {};

        $scope.logOut = function () {
            //loginService.logOut();
            //$window.location.href = '/login';
        };

        function loadInfoUser() {

        }

    }
})(angular.module('nbtapp'));