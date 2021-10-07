using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRM_MVC.Models;
namespace SRM_MVC.Services
{
    public interface IStudentService
    {
       
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        List<Student> GetStudents();
        Student GetStudent(int id);
       List <Result> GetResult(int sid, int semid);

    
    }
}
