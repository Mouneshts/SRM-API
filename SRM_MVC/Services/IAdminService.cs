using SRM_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_MVC.Services
{
    public interface IAdminService
    {
        void AddAdmin(Admin Admin);
        void UpdateAdmin(Admin Admin);
        void DeleteAdmin(int id);
        List<Admin> GetAdmins();
        Admin GetAdmin(int id);
    }
}
