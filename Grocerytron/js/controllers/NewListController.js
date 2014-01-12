'use strict';

grocerytronApp.controller('NewListController',
    function ListController($scope, $http, $window, dataService) {
        $scope.newList = {};
        $scope.save = function () {
            dataService.addList($scope.newList)
            .then(function () {
                //success
                $window.location = "#/";
            },
            function () {
                //error
                console.error("API Error: Could not save new List.");
            });
        };
    });