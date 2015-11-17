(function () {
    'use strict';

    angular
        .module('app')
        .controller('controller', controller);

    controller.$inject = ['$location', '$scope']; 

    function controller($location, $scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'controller';
        $scope.test = 'testest';
        activate();

        function activate() { }
    }
})();
