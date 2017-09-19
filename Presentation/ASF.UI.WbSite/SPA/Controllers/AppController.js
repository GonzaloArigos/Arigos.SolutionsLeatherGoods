var app = angular.module("app", ['ngRoute']);

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
app.controller("HomeController", function ($scope, $location, LanguageService) {

    $scope.Hola = "sdaasdasdsd";
    $scope.culture = "";

    $scope.CambiarIdioma = function (culture) {
        LanguageService.GetNewLang(culture).then(
            function (d) {
               
            },
            function (error) {


            });
    }
});