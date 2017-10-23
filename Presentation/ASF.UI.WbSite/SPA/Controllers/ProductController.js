angular.module('app').controller("ProductController", ["$scope", "$location", "ProductService", "$mdDialog", function ($scope, $location, ProductService, $mdDialog) {

    $scope.Crear = false;
    $scope.Nuevo = {};
    $scope.agregarCarrito = false;


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

    $scope.dialogVerProducto = function (producto) {

        $mdDialog.show({
            templateUrl: 'SPA/Dialogs/ProductDetailDialog.html',

            controller: function ($scope, $rootScope) {
                $scope.Producto = producto;
                $scope.CantidadSeleccionada = 1;
                $scope.CartItem = {};
                $scope.OK = false;

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