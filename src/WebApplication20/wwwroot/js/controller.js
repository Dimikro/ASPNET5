(function () {
    'use strict';

    var MyApp = angular
        .module('MyApp');

    MyApp.controller('MyController', controller);

    controller.$inject = ['$location', '$scope', '$http'];
    
    function controller($location, $scope, $http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'MyController';
        $scope.messagetext = 'Enter your secret message here';
        $scope.guid = '';
        $scope.password = '';
        $scope.confirmPassword = '';
        $scope.Create = function () {
            $http.post('Message', '"' + $scope.messagetext + '"').then(
                function (result) {
                    $scope.guid = result.data;
                },
            function (result) {
            });
        };
        activate();

        function activate() { }
    }

    var compareTo = function () {
        return {
            require: "ngModel",
            scope: {
                otherModelValue: "=compareTo"
            },
            link: function (scope, element, attributes, ngModel) {

                ngModel.$validators.compareTo = function (modelValue) {
                    return modelValue == scope.otherModelValue;
                };

                scope.$watch("otherModelValue", function () {
                    ngModel.$validate();
                });
            }
        };
    };

    MyApp.directive("compareTo", compareTo);

})();
