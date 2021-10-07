using SRM_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_MVC.Services
{
    public interface IBranchService
    {
        void AddBranch(Branch Branch);
        void UpdateBranch(Branch Branch);
        void DeleteBranch(int id);
        List<Branch> GetBranchs();
        Branch GetBranch(int id);
    }
}
