using SRM_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_MVC.Services
{
    public interface ISubjectService
    {
        void AddSubject(Subjects Subject);
        void UpdateSubject(Subjects Subject);
        void DeleteSubject(int id);
        List<Subjects> GetSubjects();
        Subjects GetSubject(int id);
    }
}
