angular.module('app').controller("ProductController", ["$scope", "$location", "ProductService", function ($scope, $location, ProductService) {

    $scope.Crear = false;
    $scope.Nuevo = {};


    var all = function () {
        ProductService.GetAll().then(
            function (d) {
                $scope.ProductoViewModel = d.data;
            },
            function (error) {


            });
    }

    all();

    $scope.Delete = function (id) {
        ProductService.Delete(id).then(
            function (d) {
                all();
            },
            function (error) {


            });
    }

    $scope.Editar = function (x) {
        ProductService.Editar(JSON.stringify(x)).then(
            function (d) {

            },
            function (error) {


            });
    }

    $scope.Guardar = function (x) {
        ProductService.Guardar(JSON.stringify(x)).then(
            function (d) {

            },
            function (error) {


            });
    }

}])