angular.module("app", []).controller("controller", function ($scope, $http) {

    $http.get("/api/Bouqettes").success(function (data) {

        console.log(data);
        $scope.Bouqettes = data;

    }).error(function () {

        alert("error bouqette");

    });

    $http.get("/api/DeliveryPersons").success(function (data) {

        console.log(data);
        $scope.DeliveryPersons = data;

    }).error(function () {

        alert("error deliverypersons");

    });

    $http.get("/api/Orders").success(function (data) {

        console.log(data);
        $scope.Orders = data;

    }).error(function () {

        alert("error orders");

    });

});

