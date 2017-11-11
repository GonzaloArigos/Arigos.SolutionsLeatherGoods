angular.module("app").factory("ProductService", function ($http, $q) {


    var service = {};



    service.GetAll = function (skip) {
        var promise = $http({
            method: 'get',
            url: '/Product/GetAll',
            params: {skip: skip}
        });


        return $q.when(promise);

    };

    service.GetCartByIdClient = function (id) {
        var promise = $http({
            method: 'get',
            url: '/Product/GetCartByIdClient',
            params: {
                id: id
            }
        });

        return $q.when(promise);

    };

    service.AgregarAlCarrito = function (item) {
        var promise = $http({
            method: 'post',
            url: '/Product/AgregarAlCarrito',
            data: { item: item }
        });

        return $q.when(promise);

    };

    service.PublicarProducto = function (file,product) {
        var promise = $http({
            method: 'post',
            url: '/Product/PublicarProducto',
            data: { file: file, product: product}
        });

        return $q.when(promise);

    };

    service.ConfirmarCarrito = function (item) {
        var promise = $http({
            method: 'post',
            url: '/Product/ConfirmarCarrito'
        });

        return $q.when(promise);

    };

    return service;

})