var app = angular.module("app", ['ngRoute', 'ngMaterial', 'ngFileUpload']);

// =====================================
// configure the route navigation
// =====================================
app.config(function ($routeProvider, $locationProvider) {
    $routeProvider

        .when('/',
        {
            templateUrl: 'SPA/Home.html',
            controller: 'HomeController'
        })


        .when('/Category',
        {
            templateUrl: 'SPA/Category.html',
            controller: 'CategoryController'
        })
        .when('/AddProduct',
        {
            templateUrl: 'SPA/AddProduct.html',
            controller: 'AddProductController'
        })
        .when('/Product',
        {
            templateUrl: 'SPA/Producto.html',
            controller: 'ProductController'
        })


        .otherwise({
            templateUrl: 'SPA/Home.html',
            controller: 'HomeController'
        });

});

// Home controller
app.controller("HomeController", function ($scope, $location, LanguageService, ProductService) {

    $scope.culture = "";

    $scope.CambiarIdioma = function (culture) {
        LanguageService.GetNewLang(culture).then(
            function (d) {
               
            },
            function (error) {


            });
    }

    var all = function () {
        ProductService.GetAll(0).then(
            function (d) {
                $scope.ProductoViewModel = d.data;

                for (var i = 1; i <= $scope.ProductoViewModel.Paginas; i++) {
                    $scope.Paginas.push(i);
                }
            },
            function (error) {


            });
    }

    all();

});