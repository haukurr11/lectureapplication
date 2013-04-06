var app = angular.module("Prog5", []);

app.config(function ($routeProvider) {
    $routeProvider.when('/lectures', {
        templateUrl: '/Content/views/lectures.html',
        controller: 'LectureListController'
    }).when('/lecture/:id', {
        templateUrl: '/Content/views/lecture.html',
        controller: 'LectureController'
    }).otherwise({
        redirectTo: '/lectures'
    });
});