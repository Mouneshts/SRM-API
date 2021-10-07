using SRM_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_MVC.Services
{
   public interface IResultService
    {
        void AddResult(Result Result);
        void UpdateResult(Result Result);
        void DeleteResult(int id);
        List<Result> GetResults();
        Result GetResult(int id);
    }
}
