using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using MyLectureApplication.Controllers;

namespace MyLectureApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/lectures/{LectureID}/{controller}/{commentID}",
                defaults: new { id = RouteParameter.Optional,controller="CommentsController" }
            );
            config.Routes.MapHttpRoute(
               name: "Lectures",
               routeTemplate: "api/v1/{controller}/{LectureID}",
               defaults: new { id = RouteParameter.Optional, controller = "LecturesController" }
           );
            config.Routes.MapHttpRoute(
               name: "Comments",
               routeTemplate: "api/v1/lectures/{LectureID}/{controller}",
               defaults: new { id = RouteParameter.Optional, controller = "CommentsController" }
           );
        }
    }
}
