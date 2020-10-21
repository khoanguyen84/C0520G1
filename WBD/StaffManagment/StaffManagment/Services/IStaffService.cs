using StaffManagment.Models.Entities;
using StaffManagment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagment.Services
{
    public interface IStaffService
    {
        IEnumerable<Province> GetProvinces();
        IEnumerable<District> GetDistricts(int provinceId);
        IEnumerable<Ward> GetWards(int districtId, int provinceId);
        int CreateStaff(Staff staff );
        IEnumerable<StaffView> GetStaffs();
        Staff GetStaff(int id);
        int UpdateStaff(UpdateStaff model);
        int DeleteStaff(int id);
        List<Province> GetAllProvinces();
    }
}
