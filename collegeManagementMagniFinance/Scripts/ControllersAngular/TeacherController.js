var app = angular.module("Teacherapp", []);



app.controller("TeacherController", function ($scope, $http) {

    $scope.btntext = "Save";

    // Add record

    $scope.savedata = function () {

        $http({

            method: 'POST',

            url: '/Teacher/Create',

            data: $scope.teacherModel

        }).then(function (d) {

            
            alert("Ok");
            window.location.href = "/Teacher/index";

        }).error(function () {

            alert('Failed');

        });

    };

    // Display all record

    $http.get("/Teacher/GetListTeachers").then(function (d) {

        $scope.Teachers = d.data;

    }, function (error) {

        alert('Failed');
        console.log(error)

    });

    // Display record by id

    $scope.loadTeacher = function (id) {

        $http.get("/Teacher/GetTeacherById?id=" + id).then(function (d) {

            $scope.register = d.data;

        }, function (error) {

            alert('Failed');

        });

    };

    // Delete record

    $scope.deleteTeacher = function (id) {

        $http.post("/Teacher/Delete/" + id).then(function (d) {


            $http.get("/Teacher/GetListTeachers").then(function (d) {
                $filter('date')(myDate, "YYYY-MM-DDThh:mm");
                $scope.Teachers = d.data;

            }, function (error) {

                window.location.href = "/Teacher/index";

            });

        }, function (error) {

            alert('Failed delete');

        });

    };

    // Update record
    $scope.updatedata = function (data) {
        var dateTimeSpan = data.Birthday.slice(6, -2)
        data.Birthday = new Date(parseInt(dateTimeSpan));

        $http({

            method: 'POST',

            url: '/Teacher/Edit',

            data: data
        }).then(function (d) {
            window.location.href = "/Teacher/index";

        }).error(function () {

            window.location.href = "/Teacher/index";

        });

    };

});