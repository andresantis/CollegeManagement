var app = angular.module("Studentapp", []);



app.controller("StudentController", ['$scope', '$http', '$filter', function ($scope, $http, $filter) {

    $scope.btntext = "Save";

    // Add record

    $scope.savedata = function () {

        $http({

            method: 'POST',

            url: '/Student/Create',

            data: $scope.studentModel

        }).then(function (d) {

            $scope.btntext = "Save";

            $scope.studentModel = null;
            window.location.href = "/Student/index";

        }).error(function () {

            alert('Failed');

        });

    };

    // Display all record

    $http.get("/Student/GetListStudents").then(function (d) {

        $scope.Students = d.data;

    }, function (error) {

        alert('Failed');
        console.log(error)

    });

    // Display record by id

    $scope.loadStudent = function (id) {

        $http.get("/Student/GetStudentById?id=" + id).then(function (d) {

            $scope.register = d.data;

        }, function (error) {

            alert('Failed');
            

        });

    };

    // Delete record

    $scope.deleteStudent = function (id) {

        $http.post("/Student/Delete/" + id).then(function (d) {


            $http.get("/Student/GetListStudents").then(function (d) {
                $filter('date')(myDate, "YYYY-MM-DDThh:mm");
                $scope.Students = d.data;

            }, function (error) {

                alert('Failed to load a Students list');

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

            url: '/Student/Edit',

            data: data
        }).then(function (d) {

            window.location.href = "/Student/index";

        }).error(function () {

            alert('Failed');

        });

    };

}]);