app.controller("LectureListController", function ($scope, $location,$http) {
    $scope.username = "";
    $scope.newLecture = { Name: "" , LectureURL: "" }
    $scope.lectures = [];
    $http.get('/api/v1/currentuser').success(function (data) {
        $scope.username = data.FullName;
    });
    function refreshLectures() {
        $http.get('/api/v1/lectures').success(function (data) {
            $scope.lectures = data;

            for (var lec in $scope.lectures) {
                $scope.lectures[lec].DatePublished = (new Date($scope.lectures[lec].DatePublished)).toUTCString();
            }

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