angular.module("app").factory("CategoryService", function ($http, $q) {


    var service = {};


    service.GetAll = function () {
        var promise = $http({
            method: 'get',
            url: '/Category/Index'
        });

        return $q.when(promise);

    };

    //service.Delete = function (id) {
    //    var promise = $http({
    //        method: 'post',
    //        url: '/Category/Remove',
    //        data = {id: id}
    //    });

    //    return $q.when(promise);

    //};


    service.Delete = function (id) {
        var promise = $http({
            method: 'get',
            url: '/Category/Remove',
            params: {
                id: id
            }
        });
   

        return $q.when(promise);

    };

    service.Editar = function (category) {
        var promise = $http({
            method: 'post',
            url: '/Category/FindByEdit',
            data: {
                category: category
            }
        });

        return $q.when(promise);

    };

    service.Guardar = function (category) {
        var promise = $http({
            method: 'post',
            url: '/Category/Create',
            data: {
                category: category
            }
        });

        return $q.when(promise);

    };

    return service;

})