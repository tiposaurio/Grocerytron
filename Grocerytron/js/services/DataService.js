grocerytronApp.factory("dataService", function ($http, $q) {
    var _lists = [];
    var _isInit = false;

    var _isReady = function () {
        return _isInit();
    };

    var _getLists = function () {

        var deffered = $q.defer();

        $http.get("/api/lists?includeItems=true")
            .then(function (result) {
                angular.copy(result.data, _lists);
                _isInit = true;
                deffered.resolve();
            },
            function () {
                deffered.reject();
            });

        return deffered.promise;
    };

    var _addList = function (newList) {
        var deffered = $q.defer();

        $http.post("/api/lists", newList)
                .then(function (result) {
                    var newlyCreatedList = result.data;
                    _lists.splice(0, 0, newlyCreatedList);
                    deffered.resolve(newlyCreatedList);
                },
                function () {
                    deferred.reject();
                });

        return deffered.promise;
    };

    function _findList(id) {
        var found = null;

        $.each(_lists, function (i, list) {
            if (list.id == id) {
                found = list;
                return false;
            }
        });

        return found;
    }

    var _getListById = function (id) {
        var deffered = $q.defer();
        _getLists()
        .then(function () {
            var list = _findList(id);
            if (list) {
                deffered.resolve(list);
            } else {
                deffered.reject();
            }
        },
        function () {

        })
        return deffered.promise;
    };

    var _saveItem = function (list, newItem) {
        var deffered = $q.defer();

        $http.post("/api/lists/" + list.id + "/items", newItem)
        .then(function (result) {
            if (list.items == null) list.items = [];
            list.items.push(result.data);
            deffered.resolve(result.data);
        },
        function () {
            deffered.reject();
        });

        return deffered.promise;
    }

    return {
        lists: _lists,
        getLists: _getLists,
        addList: _addList,
        getListById: _getListById,
        saveItem: _saveItem
    };
});