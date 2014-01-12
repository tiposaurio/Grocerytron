'use strict';

grocerytronApp.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: '/templates/listView.html',
            controller: 'ListController'
        })
        .otherwise({ redirectTo: '/' });

    $routeProvider
        .when("/newlist", {
            templateUrl: '/templates/newListView.html',
            controller: 'NewListController'
        })
        .otherwise({ redirectTo: '/' });

    $routeProvider
        .when("/list/:id", {
            templateUrl: '/templates/singleListView.html',
            controller: 'singleListController'
        })
        .otherwise({ redirectTo: '/' });
});



grocerytronApp.controller('ListController',
    function ListController($scope, $http, dataService) {
        $scope.isBusy = true;
        $scope.data = dataService;

        dataService.getLists()
        .then(function () {
            //success
            console.log($scope.data);
        },
        function () {
            //error
            console.error("API Failure");
        })
        .then(function () {
            $scope.isBusy = false;
        });
    }
);