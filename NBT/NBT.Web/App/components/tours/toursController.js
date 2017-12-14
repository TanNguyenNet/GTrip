﻿(function (app) {
    'use strict';

    app.controller('toursController', toursController);

    toursController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function toursController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
        $scope.page = 0;
        $scope.pageSize = "50";
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.filter = '';

        $scope.filterCountry = {};

        $scope.data = [];
        $scope.search = search;

        function search(page) {
            $scope.loading = true;
            page = page || 0;
            var config = {
                params: {
                    filter: $scope.filter,
                    countryRegionId: $scope.filterCountry.countryRegionId,
                    stateProvinceId: $scope.filterCountry.stateProvinceId,
                    page: page,
                    pageSize: $scope.pageSize
                }
            };
            apiService.get('/api/tours/getAll', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.data = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;
            }, function () {
                console.log('load failed data');
                $scope.loading = false;
            });
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
            }, function () {
                console.log('Cannot get data');
            });
        }

        loadCountryRegions();
        loadStateProvinces();
        $scope.search();
    }
})(angular.module('nbtapp.tours'));