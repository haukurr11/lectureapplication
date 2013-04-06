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
        public LectureViewModel Get(int id)
        {
            LectureViewModel vm = new LectureViewModel();
            var lec = (from l in db.Lectures
                       where l.ID == id
                       select l).FirstOrDefault();
            vm.Title = lec.Name;
            vm.ID = id;
            vm.VideoURL = lec.LectureURL;
            var result = (from c in db.Comments
                         where c.Lecture.ID == id
                          select c).AsEnumerable().Reverse();
            if (result == null)
                throw new FieldAccessException("Nothing found in db.Comments");
            foreach( Comment c in result) {
                CommentContainer cc = new CommentContainer();
                cc.AuthorName = c.Poster.FullName;
                cc.PublishedDate = c.DatePublished.ToUniversalTime().ToString();
                cc.CommentText = c.CommentText;
                vm.comments.Add(cc);
            }
            return vm;
        }

        // POST api/comments
        [Authorize]
        public void Post(int id,Comment com)
        {
            if (com.CommentText.Length > 0)
            {
                com.DatePublished = DateTime.Now;
                com.Poster = (from user in db.UserProfiles
                              where user.UserName == User.Identity.Name
                              select user).FirstOrDefault();
                com.Lecture = (from lecture in db.Lectures
                               where lecture.ID == id
                               select lecture).SingleOrDefault();
                com.ID = 0;
                db.Comments.Add(com);
                db.SaveChanges();
            }
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
