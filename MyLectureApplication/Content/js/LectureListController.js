app.controller("LectureListController", function ($scope, $location,$http) {
    $scope.username = "";
    $scope.lectures = [];
    $http.get('/api/v1/currentuser').success(function (data) {
        $scope.username = data.FullName;
    });
    $http.get('/api/v1/lectures').success(function (data) {
        $scope.lectures = data;

        for (var lec in $scope.lectures) {
            $scope.lectures[lec].DatePublished = (new Date($scope.lectures[lec].DatePublished)).toUTCString();
        }
    });
    $scope.viewlecture = function (id) {
        $location.path("/lecture/" + id);
    }
});