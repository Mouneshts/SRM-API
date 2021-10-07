using SRM_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_MVC.Services
{
    public interface ISemesterService
    {
        void AddSemester(Semester Semester);
        void UpdateSemester(Semester Semester);
        void DeleteSemester(int id);
        List<Semester> GetSemesters();
        Semester GetSemester(int id);
    }
}
