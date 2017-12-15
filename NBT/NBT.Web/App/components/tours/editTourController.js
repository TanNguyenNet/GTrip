(function (app) {

    app.controller('editTourController', editTourController);

    editTourController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams'];

    function editTourController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.data = {
            
        };
        $scope.chooseImage = chooseImage;
        $scope.save = save;
        $scope.addAttr = addAttr;
        $scope.addValue = addValue;

        $scope.ckeditorOptions = function () {

        };

        function addValue(item) {
            if (item.Checked) {
                for (var i in $scope.data.TourAttr) {
                    if ($scope.data.TourAttr[i].TourAttributeId === item.Id) {
                        $scope.data.TourAttr[i].Value = item.Value;
                        break;
                    }
                }
            }
        }

        function addAttr(item) {
            if (item.Checked) {
                var attr = {
                    TourAttributeId: item.Id,
                    Value: item.Value
                };
                $scope.data.TourAttr.push(attr);
            } else {
                for (var i in $scope.data.TourAttr) {
                    if ($scope.data.TourAttr[i].TourAttributeId === item.Id) {
                        cart.Carts.splice(i, 1);
                        break;
                    }
                }
            }

        }

        function save() {
            $("input").prop('disabled', true);

            $scope.data.ToDate = moment($scope.data.ToDate, "DD/MM/YYYY").format();
            $scope.data.FromDate = moment($scope.data.FromDate, "DD/MM/YYYY").format();

            apiService.put('api/tours/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã được thêm mới.');
                    $state.go('tours');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

        function chooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.data.Image = fileUrl;
                });
            };
            finder.popup();
        }

        function loadCountryRegions() {
            apiService.get('api/countryRegion/getAllNoPaging', null, function (result) {
                $scope.countryRegions = result.data;
            }, function () {
                console.log('Cannot get data');
            });
        }

        function loadStateProvinces() {
            apiService.get('api/stateProvince/getAllNoPaging', null, function (result) {
                $scope.stateProvinces = result.data;
                loadDetail();
            }, function () {
                console.log('Cannot get data');
            });
        }

        function loadTourAttr() {
            apiService.get('api/tourAttributes/getAll', null, function (result) {
                $scope.dataAttr = result.data;
                for (var j in $scope.dataAttr){
                    for (var i in $scope.data.TourAttr) {
                        if ($scope.dataAttr[j].Id === $scope.data.TourAttr[i].TourAttributeId) {
                            $scope.dataAttr[j].Value = $scope.data.TourAttr[i].Value;
                            $scope.dataAttr[j].Checked = true;
                            break;
                        }
                    }
                }
            }, function () {
                console.log('Cannot get data');
            });
        }

        function loadDetail() {
            apiService.get('api/tours/getbyid/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
                loadTourAttr();
                $scope.data.ToDate = moment($scope.data.ToDate).format('DD/MM/YYYY');
                $scope.data.FromDate = moment($scope.data.FromDate).format('DD/MM/YYYY');
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        
        loadCountryRegions();
        loadStateProvinces();
        
        
        
        $('#datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' });
        $('#datemask2').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' });
        $('[data-mask]').inputmask();
    }

})(angular.module('nbtapp.tours'));