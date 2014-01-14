grocerytronApp.controller('singleListController',
    function ListController($scope, $window, $routeParams, dataService) {
        $scope.list = null;
        $scope.newItem = {};
        $scope.isBusy = true;

        dataService.getListById($routeParams.id)
        .then(function (list) {
            //success
            $scope.list = list;
        },
        function () {
            //error
            $window.location = "#/";
        })
        .then(function () {
            $scope.isBusy = false;
        });

        $scope.addItem = function () {
            dataService.saveItem($scope.list, $scope.newItem)
            .then(function () {
                $scope.newItem.body = {};
            },
            function () {
                console.error("API Error: Could not add item")
            });
        };
    });