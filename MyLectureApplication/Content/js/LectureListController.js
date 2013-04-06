app.controller("LectureListController", function ($scope, $location,$http) {
    $scope.UserFullName = "";
    $scope.newLecture = { Name: "" , LectureURL: "" }
    $scope.lectures = [];
    function refreshLectures() {
        $http.get('/api/v1/lectures').success(function (data) {
            $scope.lectures = data.lectures;
            $scope.UserFullName = data.UserFullName;
        });
    }
    refreshLectures();
    $scope.viewlecture = function (id) {
        $location.path("/lecture/" + id);
    }
    $scope.addLecture = function () {
        $http.post("/api/v1/lectures/", $scope.newLecture).success(function () {
            refreshLectures();
        });

    }
});