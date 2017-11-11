angular.module('app').controller("AddProductController", ["$scope", "$location", "ProductService", "$mdDialog", "Upload", function ($scope, $location, ProductService, $mdDialog, Upload) {
    $scope.uploadFiles = function (file, errFiles) {
        $scope.f = file;
        $scope.errFile = errFiles && errFiles[0];
        if (file) {
            file.upload = Upload.upload({
                url: '/Product/VerFoto',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $scope.Image = response.data;
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (response) {
                file.progress = Math.min(100, parseInt(100.0 *
                    evt.loaded / evt.total));
            });


        }
    }

    $scope.Producto = {};

    $scope.AgregarProducto = function () {
        $scope.OK = true;
        $scope.ArchivoImg.upload = Upload.upload({
            url: '/Product/PublicarProducto',
            data: { file: $scope.f, product: JSON.stringify($scope.Producto) }
        });

        file.upload.then(function (response) {
            $scope.Producto.IdImage = response.data.IdImage;
            $scope.Imagen = response.data.Image;
            $scope.OK = true;
        }, function (response) {
            if (response.status > 0)
                $scope.errorMsg = response.status + ': ' + response.data;
        }, function (response) {
            file.progress = Math.min(100, parseInt(100.0 *
                evt.loaded / evt.total));
        });
    }

}])