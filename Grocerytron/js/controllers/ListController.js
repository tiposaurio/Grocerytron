'use strict';

grocerytronApp.controller('ListController',
    function ListController($scope, $http) {
        $scope.isBusy = true;
        $scope.data = [];
        $http.get("/api/lists?includeItems=true")
            .then(function (result) {
                angular.copy(result.data, $scope.data);
            },
            function () {
                alert("Error: API is not working!")
            })
            .then(function () {
                $scope.isBusy = false;
            });
    }
);