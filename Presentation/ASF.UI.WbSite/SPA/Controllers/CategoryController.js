angular.module('app').controller("CategoryController", ["$scope", "$location", "CategoryService", function ($scope, $location, CategoryService) {

    $scope.Crear = false;
    $scope.Nuevo = {};


    var all = function () {
        CategoryService.GetAll().then(
            function (d) {
                $scope.CategoriasViewModel = d.data;
            },
            function (error) {


            });
    }

    all();

    $scope.Delete = function (id)       {
        CategoryService.Delete(id).then(
            function (d) {
                all();
            },
            function (error) {


            });
    }

    $scope.Editar = function (x) {
        CategoryService.Editar(JSON.stringify(x)).then(
            function (d) {
             
            },
            function (error) {


            });
    }

    $scope.Guardar = function (x) {
        CategoryService.Guardar(JSON.stringify(x)).then(
            function (d) {

            },
            function (error) {


            });
    }

}])