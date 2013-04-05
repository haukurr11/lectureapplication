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
        // GET api/comments
        public IEnumerable<Comment> Get(int id)
        {
            var result =  from comment in db.Comments
                          where comment.Lecture.ID == id
                          select comment;
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
