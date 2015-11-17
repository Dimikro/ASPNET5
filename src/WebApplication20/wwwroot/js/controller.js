(function () {
    'use strict';

    angular
        .module('MyApp')
        .controller('MyController', controller);

    controller.$inject = ['$location', '$scope']; 

    function controller($location, $scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'MyController';
        $scope.test = 'testest';
        $scope.Create = function () {
        };
        activate();

        function activate() { }
    }
})();
