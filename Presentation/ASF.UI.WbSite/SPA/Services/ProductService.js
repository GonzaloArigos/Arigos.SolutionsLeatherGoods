angular.module("app").factory("ProductService", function ($http, $q) {


    var service = {};



    service.GetAll = function () {
        var promise = $http({
            method: 'get',
            url: '/Product/GetAll'
        });


        return $q.when(promise);

    };



    return service;

})