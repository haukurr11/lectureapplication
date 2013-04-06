app.controller("LectureController", function ($scope, $location, $http, $routeParams) {
    $scope.lecture = null;
    $scope.comments = [];

    $http.get('/api/v1/lectures/' + $routeParams.id).success(function (data) {
        var vidvar = data.LectureURL.lastIndexOf("v=")+2;
        var parameter = data.LectureURL.substring(vidvar, data.LectureURL.length);
        data.LectureURL = "http://www.youtube.com/embed/" + parameter;
        $scope.lecture = data;
    });
     $http.get('/api/v1/lectures/' + $routeParams.id + "/comments").success(function (data) {
         $scope.comments = data;
         for (c in $scope.comments) {
             $scope.comments[c].DatePublished = (new Date($scope.comments[c].DatePublished)).toUTCString();
         }
     });

     $scope.backtolectures = function () {
         $location.path("/lectures/");
     }
});