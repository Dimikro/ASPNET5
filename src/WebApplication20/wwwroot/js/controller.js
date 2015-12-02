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
        $scope.confirmPassword = null;

        $scope.message={
            Guid: undefined,
            PasswordHash: undefined,
            Text: undefined,
            HoursToDelete: '0',
            Url: undefined
        }

        $scope.Create = function () {
            $http.post('Message', $scope.message).then(
                function (result) {
                    $scope.message.Guid = result.data;
                    $scope.message.Url = 'http://localhost:43815/Message/' + $scope.message.Guid;
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
