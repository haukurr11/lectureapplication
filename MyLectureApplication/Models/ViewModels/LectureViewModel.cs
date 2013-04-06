﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLectureApplication.Models;
using System.Diagnostics;

namespace MyLectureApplication.Models
{
    public class CommentContainer
    {
        public string AuthorName { get; set; }
        public string CommentText { get; set; }
        public string PublishedDate { get; set; }
    }

    public class LectureViewModel
    {
        public LectureViewModel()
        {
            comments = new List<CommentContainer>();
        }
        #region Properties
        public string Title { get; set; }
        public string VideoURL { get; set; }
        public List<CommentContainer> comments { get; set; }
        public int ID { get; set; }
        #endregion
    }
}