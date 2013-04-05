using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
               name: "DefaultApi",
               routeTemplate: "api/v1/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional}
           );
        }
    }
}
