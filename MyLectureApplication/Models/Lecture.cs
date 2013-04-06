using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLectureApplication.Models
{
    public class Lecture
    {
        #region Properties
        public int ID { get; set; }
        public string LectureURL { get; set; }
        public DateTime DatePublished { get; set; }
        public virtual UserProfile Teacher { get; set; }
        public string Name { get; set; }
        #endregion
    }
}