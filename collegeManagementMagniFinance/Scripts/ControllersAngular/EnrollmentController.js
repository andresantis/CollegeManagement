var app = angular.module("Enrollmentapp", []);



app.controller("EnrollmentController", function ($scope, $http) {

    $scope.btntext = "Save";

    // Add record

    $scope.savedata = function () {
        $scope.enrollmentModel.StudentId = $scope.enrollmentModel.selectedStudent.studentId;
        $scope.enrollmentModel.SubjectId = $scope.enrollmentModel.selectedSubject.Id;

        $http({

            method: 'POST',

            url: '/Enrollment/Create',

            data: $scope.enrollmentModel
            
        }).then(function (d) {

            $scope.btntext = "Save";

            $scope.register = null;
            alert("Success");
            window.location.href = "/Enrollment/index";
            

        })

    };

    // Display all record

    $http.get("/Enrollment/GetListEnrollments").then(function (d) {

        $scope.Enrollments = d.data;

    }, function (error) {

        alert('Failed');

    });

    // Display record by id

    $scope.loadEnrollment = function (id) {

        $http.get("/Enrollment/GetEnrollmentById?id=" + id).then(function (d) {

            $scope.register = d.data;

        }, function (error) {

            alert('Failed');

        });

    };


    $scope.getItemsToCreateGrade = function () {

        $http.get("/Enrollment/GetStudentsAndSubjects").then(function (d) {

            $scope.createRegister = d.data;

        }, function (error) {

            alert('Failed');

        });

    };

    // Delete record

    $scope.deleteEnrollment = function (id) {

        $http.post("/Enrollment/Delete/" + id).then(function (d) {

            alert(d.data);

            $http.get("/Enrollment/GetListCourses").then(function (d) {

                $scope.Courses = d.data;

            }, function (error) {

                window.location.href = "/Enrollment/index";

            });

        }, function (error) {

           

        });

    };


    // Update record
    $scope.updatedata = function (data) {

        data.StudentId = data.student.Id;
        data.SubjectId = data.subject.Id;

        $http({

            method: 'POST',

            url: '/Enrollment/Edit',

            data: data
        }).success(function (d) {

            $scope.register = null;

            alert("Success");
            window.location.href = "/Enrollment/index";

        }).error(function () {

            alert('Failed');

        });

    };

});