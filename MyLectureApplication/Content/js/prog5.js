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
myApp.directive('ngIf', function () {
    return {
        link: function (scope, element, attrs) {
            if (scope.$eval(attrs.ngIf)) {
                // remove '<div ng-if...></div>'
                element.replaceWith(element.children())
            } else {
                element.replaceWith(' ')
            }
        }
    }
});
