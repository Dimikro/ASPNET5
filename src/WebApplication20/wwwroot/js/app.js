(function () {
    'use strict';

    var MyApp = angular.module('MyApp', [

        // Angular modules 
        //'ngRoute'

        // Custom modules 

        // 3rd Party Modules
        "ngMessages",
        "ui.router"
    ]);

    MyApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

        $urlRouterProvider.otherwise('/Home');

        $stateProvider

            // HOME STATES AND NESTED VIEWS ========================================
            .state('home', {
                url: '/Home',
                templateUrl: 'Home/IndexPartial'
            })

            // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
            .state('about', {
                url: '/Home/About',
                templateUrl: 'AboutPartial'
            })

            //
            .state('register', {
                url: '/Account/Register',
                templateUrl: 'RegisterPartial'
            })

            //
            .state('login', {
                url: '/Account/Login',
                templateUrl: 'LoginPartial'
            })
            ;
    });
})();