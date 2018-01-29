(function (app) {
    var ListController = function ($scope,$http)
    {
        $http.get("/api/movie")
        .then(
                function (data) {
                    $scope.movies = data;
                    console.log(data)
                }
            )
    };
    //ListController.$inject = ["$scope", "$http"];
    app.controller("ListController", ListController);
}(angular.module("atTheMovies")))