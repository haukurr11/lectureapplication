app.controller("LectureController", function ($scope, $location, $http, $routeParams,$timeout) {
    $scope.lecture = null;
    $scope.comments = [];
    $scope.newcomment = { CommentText: "" };


function LoadViewModel() {
        $http.get('/api/v1/lectures/' + $routeParams.id + "/comments").success(function (data) {
            var vidvar = data.VideoURL.lastIndexOf("v=") + 2;
            var parameter = data.VideoURL.substring(vidvar, data.VideoURL.length);
            data.VideoURL = "http://www.youtube.com/embed/" + parameter;
            $scope.lecture = { LectureURL: data.VideoURL, Name: data.Title, ID: data.ID };
            $scope.comments = data.comments;
        });
    }
    LoadViewModel();

     $scope.postcomment = function () {
         $http.post('/api/v1/lectures/' + $scope.lecture.ID + '/comments', $scope.newcomment).success(function () {
             LoadViewModel();
             $scope.newcomment.CommentText = "";
             $scope.apply();
         });
     }
     $scope.backtolectures = function () {
         $location.path("/lectures/");
     }
});

