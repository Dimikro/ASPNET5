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
        $scope.messagetext = 'Enter your secret message here';
        $scope.guid = '';
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
})();
