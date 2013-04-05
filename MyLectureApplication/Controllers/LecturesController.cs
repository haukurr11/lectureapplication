using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyLectureApplication.Models;

namespace MyLectureApplication.Controllers
{
    public class LecturesController : ApiController
    {
        AppDataContext db = new AppDataContext();

        // GET api/lectures
        public IEnumerable<Lecture> Get()
        {
            return db.Lectures;
        }

        // GET api/lectures/5
        public Lecture Get(int id)
        {
            var result = (from lecture in db.Lectures 
                           where lecture.ID == id 
                           select lecture).SingleOrDefault();
            if (result == null)
            {
                //throw new HttpResponseException("Not found");
            }
            return result;
        }

        // POST api/lectures
        public void Post([FromBody]string value)
        {
        }

        // PUT api/lectures/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/lectures/5
        public void Delete(int id)
        {
        }
    }
}
