using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyLectureApplication.Models;

namespace MyLectureApplication.Controllers
{
    public class CommentsController : ApiController
    {
        AppDataContext db = new AppDataContext();
        // GET api/comment

        // GET api/comments/5
        [Authorize]
        public IEnumerable<Comment> Get(int id)
        {
            var result = from c in db.Comments
                         where c.Lecture.ID == id 
                         select c;
                          
            if (result == null)
                        throw new FieldAccessException("Nothing found in db.Comments");
            return result;
        }

        // POST api/comments
        [Authorize]
        public void Post(int id,[FromBody]string value)
        {
            Console.WriteLine("hallo");
        }

        // PUT api/comments/5
        [Authorize(Roles = "Teachers")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/comments/5
        [Authorize(Roles="Teachers")]
        public void Delete(int id)
        {
        }
    }
}
