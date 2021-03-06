﻿angular.module('app').controller("ProductController", ["$scope", "$location", "ProductService", "$mdDialog", "$timeout", "$q", "$log", function ($scope, $location, ProductService, $mdDialog, $timeout, $q, $log) {

    $scope.Crear = false;
    $scope.Nuevo = {};
    $scope.agregarCarrito = false;
    $scope.Skip = 0;
    $scope.Paginas = [];

    $scope.EstaBuscando = function () {
        if ($scope.EsBusqueda){
            return true;
        } else {
            return false;
        }
    }

    var all = function () {

        ProductService.GetAll($scope.Skip).then(
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

    $scope.VerPagina = function (pagina) {
        if (pagina == 1) {
            $scope.Skip = 0;
        } else {
            $scope.Skip = ($scope.ProductoViewModel.Take * pagina) - $scope.ProductoViewModel.Take;
        }
        all();
    }

    $scope.VerMas = function () {
        $scope.Skip = $scope.Skip + $scope.ProductoViewModel.Take;
        all();
    }

    $scope.VerMenos = function () {

        if ($scope.Skip > 0) {
            $scope.Skip = $scope.Skip - $scope.ProductoViewModel.Take;
            all();
        }

    }

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

    var self = this;

    self.simulateQuery = false;
    self.isDisabled = false;


    // ******************************
    // Internal methods
    // ******************************

    /**
     * Search for repos... use $timeout to simulate
     * remote dataservice call.
     */
    $scope.ResultadosTxt = [];
    function querySearch(query) {
        //var results = query ? self.repos.filter(createFilterFor(query)) : self.repos.Nombres,
        //    deferred;
        //if (self.simulateQuery) {
        //    deferred = $q.defer();
        //    $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
        //    return deferred.promise;
        //} else {
        //    return results;
        //}
        $scope.ResultadosTxt = [];
        for (var i = 0; i < $scope.Nombres.length; i++){
            var nombre = "";
            nombre = $scope.Nombres[i].name;
            if (nombre.toLowerCase().startsWith(query)) {
                $scope.ResultadosTxt.push($scope.Nombres[i]);
            }
        }
        
        return $scope.ResultadosTxt;
    }

    function searchTextChange(text) {
        $log.info('Text changed to ' + text);
    }


    function selectedItemChange(item) {
        ProductService.GetByName(item.name).then(
            function (d) {
                $scope.EsBusqueda = true;
                $scope.ResultadoBusqueda = d.data;
                $scope.dialogVerProducto($scope.ResultadoBusqueda[0]);
                return;
            },
            function (error) {

                $scope.EsBusqueda = true;
            });
        $scope.EsBusqueda = true;
    }

    /**
 * Create filter function for a query string
 */
    function createFilterFor(query) {
        var lowercaseQuery = angular.lowercase(query);

        return function filterFn(item) {
            return (item.value.indexOf(lowercaseQuery) === 0);
        };

    }

    /**
     * Build `components` list of key/value pairs
     */
    function loadAll() {
        var repos = [];
        ProductService.GetAllNames().then(
            function (d) {
                $scope.Nombres = d.data;
                for (var i = 0; i < $scope.Nombres.length; i++) {
                    repos.push({ 'name': $scope.Nombres[i].name });
                }

                return repos.map(function (repo) {
                    repo.value = repo.name.toLowerCase();
                    return repo;
                });
            },
            function (error) {


            });

       
    }


    self.repos = loadAll();
    self.querySearch = querySearch;
    self.selectedItemChange = selectedItemChange;
    self.searchTextChange = searchTextChange;

    $scope.dialogVerProducto = function (producto) {

        $mdDialog.show({
            templateUrl: 'SPA/Dialogs/ProductDetailDialog.html',

            controller: function ($scope, $rootScope) {
                $scope.Producto = producto;
                $scope.CantidadSeleccionada = 1;
                $scope.CartItem = {};
                $scope.OK = false;

                $scope.Cerrar = function() {
                    $mdDialog.hide();
                }

                $scope.agregarAlCarrito = function () {

                    $scope.CartItem = {
                        CartId: 0,
                        ProductId: $scope.Producto.Id,
                        Quantity: $scope.CantidadSeleccionada,
                        Price: $scope.Producto.Price
                    };

                    ProductService.AgregarAlCarrito(JSON.stringify($scope.CartItem)).then(
                        function (d) {
                            $scope.OK = true;
                        },
                        function (error) {


                        });

                }

            },
            parent: angular.element(document.body),
            clickOutsideToClose: true,
            fullscreen: true,
        })
            .openFrom('#left')
            .finally(function () {

            });
    };

    $scope.dialogVerCarrito = function () {

        $mdDialog.show({
            templateUrl: 'SPA/Dialogs/CarritoDialog.html',

            controller: function ($scope, $rootScope) {
                $scope.Carrito = [{}];
                $scope.NohayItems = false;
                $scope.verCarrito = function (id) {
                    ProductService.GetCartByIdClient(id).then(
                        function (d) {
                            $scope.Carrito = d.data;
                            if ($scope.Carrito.CartItem.length < 1) {
                                $scope.NohayItems = true;
                            }
                        },
                        function (error) {


                        });
                }

                $scope.verCarrito(1);

                $scope.Cerrar = function () {
                    $mdDialog.hide();
                }

                $scope.ElaborarResumenPago = function () {
                    $scope.Procesar = true;
                    $scope.CantidadItems = 0;
                    $scope.CantidadProductos = 0;
                    $scope.TotalPagar = 0;
                    $scope.ImporteTax = 0;
                    $scope.ImporteSinImpuestos = 0;

                    for (var i = 0; i < $scope.Carrito.CartItem.length; i++) {
                        $scope.CantidadItems = $scope.CantidadItems + 1;
                        $scope.CantidadProductos = $scope.CantidadProductos + $scope.Carrito.CartItem[i].Quantity;
                        $scope.TotalPagar = $scope.TotalPagar + ($scope.Carrito.CartItem[i].Price * $scope.Carrito.CartItem[i].Quantity);
                    }
                    $scope.Tax = '21%';
                    $scope.ImporteTax = ($scope.TotalPagar * 21) / 100;
                    $scope.ImporteSinImpuestos = $scope.TotalPagar - $scope.ImporteTax;
                }

                $scope.ConfirmarCarrito = function () {
                    ProductService.ConfirmarCarrito().then(
                        function (d) {
                            $scope.CompraFinalizada = true;
                        },
                        function (error) {


                        });

                }

            },
            parent: angular.element(document.body),
            clickOutsideToClose: true,
            fullscreen: true,
        })
            .finally(function () {

            });
    };

}])