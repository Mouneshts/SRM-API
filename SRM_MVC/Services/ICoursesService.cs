using SRM_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_MVC.Services
{
    public interface ICoursesService
    {
        void AddCourse(Courses Course);
        void UpdateCourse(Courses Course);
        void DeleteCourse(int id);
        List<Courses> GetCourses();
        Courses GetCourse(int id);
    }

}
