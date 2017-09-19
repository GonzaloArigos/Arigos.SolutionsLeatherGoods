angular.module("app").factory("LanguageService", function ($http, $q) {


    var service = {};



    service.GetNewLang = function (culture) {
        var promise = $http({
            method: 'get',
            url: '/Language/GetNewLang',
            params: {
                culture: culture
            }
        });


        return $q.when(promise);

    };



    return service;

})