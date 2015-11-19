(function () {
    'use strict';

    angular
        .module('hiddenApp')
        .controller('hiddenController', hiddenController);

    hiddenController.$inject = ['$location', '$scope', '$http'];

    function hiddenController($location, $scope, $http) {
        $scope.title = 'hiddenController';
        $scope.messagetext = '';
        $scope.LoadNote = function () {
            $http.post('Message/ReadNote/' + $location.absUrl().split('guid=')[1]).then(
                function (result) {
                    $scope.messagetext = result.data;
                },
            function (result) {
            });
        };
        activate();

        function activate() { }
    }
})();
