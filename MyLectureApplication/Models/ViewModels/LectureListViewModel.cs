﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLectureApplication.Models;
using System.Diagnostics;

namespace MyLectureApplication.Models
{
    public class LectureListContainer
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public string PublishedDate { get; set; }
        public int ID { get; set; }
    }

    public class LectureListViewModel
    {
        public LectureListViewModel()
        {
            lectures = new List<LectureListContainer>();
        }
        #region Properties
        public string UserFullName { get; set; }
        public List<LectureListContainer> lectures { get; set; }
        public Boolean isTeacher { get; set; }
        #endregion
    }
}