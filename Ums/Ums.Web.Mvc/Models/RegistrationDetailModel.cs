using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ums.Entities;

namespace Ums.Web.Mvc.Models
{
    public class CourseSectionModel
    {
        public CourseSectionModel()
        {
            Sections = new List<SectionStudentModel>();
        }

        public Course Course{ get; set; }        
        public ICollection<SectionStudentModel> Sections { get; set; }
    }

    public class SectionStudentModel
    {
        public SectionStudentModel()
        {
            Students = new List<Student>();
        }

        public Section Section { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}