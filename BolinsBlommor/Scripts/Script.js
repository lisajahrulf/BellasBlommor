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

        for (var i = 0; i < $scope.Orders.length; i++) {

            switch ($scope.Orders[i].Status) {
                case 1:
                    $scope.Orders[i].Status = "Skapad";
                    break;
                case 2:
                    $scope.Orders[i].Status = "Påbörjad";
                    break;
                case 3:
                    $scope.Orders[i].Status = "Levererad";
                    break;
            }

        }

    }).error(function () {

        alert("error orders");

    });

});

