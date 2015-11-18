(function () {
    'use strict';

    angular
        .module('MyApp')
        .controller('MyController', controller);

    controller.$inject = ['$location', '$scope', '$http'];

    function controller($location, $scope, $http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'MyController';
        $scope.test = 'testest';
        $scope.Create = function () {
            $http.post('Api/Message', '"qwe"').then(
                function (result) {
                },
            function (result) {
            });
        };
        activate();

        function activate() { }
    }
})();
