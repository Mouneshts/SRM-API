using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_MVC.Models
{
    public class StudentResultView
    {
       public List<Result> Result { get; set; }
        public Student Student { get; set; }
        public  List<Subjects> subjects{ get; set; }

        public Courses courses { get; set; }

    }
}
