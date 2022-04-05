var app = angular.module("Subjectapp", []);



app.controller("SubjectController", function ($scope, $http) {

    $scope.btntext = "Save";

    // Add record
   
    $scope.savedata = function () {
        $scope.subjectModel.CourseId = $scope.subjectModel.selectedCourse.Id;
        $scope.subjectModel.TeacherId = $scope.subjectModel.selectedTeacher.Id;
        $http({

            method: 'POST',

            url: '/Subject/Create',

            data: $scope.subjectModel

        }).then(function (d) {

            $scope.btntext = "Save";

            $scope.subjectModel = null;
            alert("Ok");
            window.location.href = "/Subject/index";

        }).error(function () {

            alert('Failed');

        });

    };

    // Display all record

    $http.get("/Subject/GetListSubjects").then(function (d) {

        $scope.subjects = d.data;

    }, function (error) {

        alert('Failed');
        console.log(error)

    });

    $scope.getOnlySubjects = function (id) {

        $http.get("/Subject/GetOnlySubjects").then(function (d) {

            $scope.allSubjects = d.data;

        }, function (error) {

            alert('Failed');

        });

    };

    // Display record by id

    $scope.loadSubject = function (id) {

        $http.get("/Subject/GetSubjectById?id=" + id).then(function (d) {

            $scope.register = d.data;

        }, function (error) {

            alert('Failed');

        });

    };

    $scope.getItemsToCreateSubject = function () {

        $http.get("/Subject/GetCourseAndTeacher").then(function (d) {

            $scope.createRegister = d.data;

        }, function (error) {

            alert('Failed');

        });

    };
    

    // Delete record

    $scope.deleteSubject = function (id) {

        $http.post("/Subject/Delete/" + id).then(function (d) {


            $http.get("/Subject/GetListSubjects").then(function (d) {
                $filter('date')(myDate, "YYYY-MM-DDThh:mm");
                $scope.subjects = d.data;

            }, function (error) {

                alert('Failed to load a Subjects list');

            });

        }, function (error) {

            alert('Failed delete');

        });

    };

    // Update record
    $scope.updatedata = function (data) {

        var subject = data;
        subject.TeacherId = data.itemSelected.Id
        subject.Teacher = data.itemSelected

        $http({

            method: 'POST',

            url: '/Subject/Edit',

            data: data
        }).then(function (d) {

            alert("Ok");
            window.location.href = "/Subject/index";

        }).error(function () {

            alert('Failed');

        });

    };

});