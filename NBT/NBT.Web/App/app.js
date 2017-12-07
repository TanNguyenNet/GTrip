
(function () {
    angular.module('nbtapp',
        [
            'nbtapp.common'
        ])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseView.html',
                abstract: true
            })
            .state('home', {
                url: '/admin',
                parent: 'base',
                templateUrl: '/app/components/home/homeView.html',
                controller: 'homeController'
            });
        $urlRouterProvider.otherwise('/admin');
    }

    function configAuthentication($httpProvider) {

        $httpProvider.interceptors.push(function ($q, $location, $window) {
            return {
                request: function (config) {
                    return config;
                },
                requestError: function (rejection) {
                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status === 401) {
                        $location.path('/admin');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {
                    if (rejection.status === 401 && rejection.headers('x-accesstokenexpired') === "1") {
                        $window.location.href = '/login';
                    }
                    else if (rejection.status === 401) {
                        $location.path('/admin');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }

})();