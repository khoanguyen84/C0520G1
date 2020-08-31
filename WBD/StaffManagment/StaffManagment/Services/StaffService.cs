using StaffManagment.Models;
using StaffManagment.Models.Entities;
using StaffManagment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagment.Services
{
    public class StaffService : IStaffService
    {
        private readonly StaffDbContext context;

        public StaffService(StaffDbContext context)
        {
            this.context = context;
        }

        public int CreateStaff(Staff staff)
        {
            context.Staffs.Add(staff);
            return context.SaveChanges();
        }

        public int DeleteStaff(int id)
        {
            var delStaff = GetStaff(id);
            if(delStaff != null)
            {
                context.Staffs.Remove(delStaff);
                return context.SaveChanges();
            }
            return -1;
        }

        public IEnumerable<District> GetDistricts(int provinceId)
        {
            return context.Districts.Where(e => e._province_id == provinceId);
        }

        public IEnumerable<Province> GetProvinces()
        {
            return context.Provinces;
        }

        public Staff GetStaff(int id)
        {
            return context.Staffs.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<StaffView> GetStaffs()
        {
            IEnumerable<StaffView> staffs = new List<StaffView>();

            staffs = (from s in context.Staffs
                      join p in context.Provinces on s.ProvinceId equals p.id
                      join d in context.Districts on s.DistrictId equals d.id
                      join w in context.Wards on s.WardId equals w.id
                      select (new StaffView()
                      {
                          Address = s.Address,
                          DistrictName = $"{d._prefix} {d._name}",
                          Email = s.Email,
                          Fullname = s.Fullname,
                          Id = s.Id,
                          PhoneNumber = s.PhoneNumber,
                          ProvinceName = p._name,
                          WardName = $"{w._prefix} {w._name}"
                      }));
            return staffs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <param name="provinceId"></param>
        /// <returns></returns>

        public IEnumerable<Ward> GetWards(int districtId = 0, int provinceId = 0)
        {
            if (provinceId != 0 && districtId != 0)
            {
                return context.Wards.Where(e => e._province_id == provinceId && e._district_id == districtId);
            }
            else if (districtId != 0)
            {
                return context.Wards.Where(e => e._district_id == districtId);
            }
            else if(provinceId != 0)
            {
                return context.Wards.Where(e => e._province_id == provinceId);
            }
            return context.Wards;
        }

        public int UpdateStaff(UpdateStaff model)
        {
            var staff = GetStaff(model.Id);
            if(staff == null)
            {
                return -1;
            }
            staff.Fullname = model.Fullname;
            staff.Address = model.Address;
            staff.Email = model.Email;
            staff.PhoneNumber = model.PhoneNumber;
            staff.ProvinceId = model.ProvinceId;
            staff.WardId = model.WardId;
            staff.DistrictId = model.DistrictId;

            context.Update(staff);
            return context.SaveChanges();
        }
    }
}
