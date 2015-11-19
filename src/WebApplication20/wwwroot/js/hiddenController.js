(function () {
    'use strict';

    angular
        .module('hiddenApp')
        .controller('hiddenController', hiddenController);

    hiddenController.$inject = ['$scope']; 

    function hiddenController($scope) {
        $scope.title = 'hiddenController';

        activate();

        function activate() { }
    }
})();
