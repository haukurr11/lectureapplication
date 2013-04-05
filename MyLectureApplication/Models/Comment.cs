using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLectureApplication.Models
{
    public class Comment
    {
        #region
        public int ID { get; set; }
        public string UserID { get; set; }
        public string CommentText { get; set; }
        public virtual Lecture Lecture { get; set; }
        #endregion
    }
}