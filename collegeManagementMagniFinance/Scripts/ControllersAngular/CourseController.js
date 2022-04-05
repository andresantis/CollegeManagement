var app = angular.module("Courseapp", []);



app.controller("CourseController", function ($scope, $http) {

    $scope.btntext = "Save";

    // Add record

    $scope.savedata = function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Course/Create',

            data: $scope.courseModel

        }).success(function (d) {

            $scope.btntext = "Save";

            $scope.register = null;

            alert("Success");

        }).error(function () {

            alert('Failed');

        });

    };

    // Display all record

    $http.get("/Course/GetListCourses").then(function (d) {

        $scope.Courses = d.data;

    }, function (error) {

        alert('Failed');

    });

    // Display record by id

    $scope.loadCourse = function (id) {

        $http.get("/Course/GetCourseById?id=" + id).then(function (d) {

            $scope.register = d.data;

        }, function (error) {

            alert('Failed');

        });

    };

    // Delete record

    $scope.deleteCourse = function (id) {

        $http.post("/Course/Delete/" + id).then(function (d) {

            alert(d.data);

            $http.get("/Course/GetListCourses").then(function (d) {

                $scope.Courses = d.data;

            }, function (error) {

                alert('Failed');

            });

        }, function (error) {

            alert('Failed');

        });

    };


    // Update record
    $scope.updatedata = function (data) {

        $http({

            method: 'POST',

            url: '/Course/Edit',

            data: data
        }).success(function (d) {

            $scope.register = null;

            alert("Success");

        }).error(function () {

            alert('Failed');

        });

    };

});