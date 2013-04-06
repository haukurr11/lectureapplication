﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLectureApplication.Models;
using System.Diagnostics;

namespace MyLectureApplication.Models
{
    public class Comment
    {
        #region Properties       
        public virtual UserProfile Poster { get; set; }
        public virtual Lecture Lecture { get; set; }
        public int ID { get; set; }
        public string CommentText { get; set; }
        public DateTime DatePublished { get; set; }      
        #endregion
    }
} 