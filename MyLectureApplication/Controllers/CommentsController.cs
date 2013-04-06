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
        public IEnumerable<string> Get(int id)
        {
            var result = from c in db.Comments
                         where c.Lecture.ID == id 
                         select c.CommentText;
                          
            if (result == null)
                        throw new FieldAccessException("Nothing found in db.Comments");

            return result;
        }

        // POST api/comments
        public void Post([FromBody]string value)
        {
        }

        // PUT api/comments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/comments/5
        public void Delete(int id)
        {
        }
    }
}
