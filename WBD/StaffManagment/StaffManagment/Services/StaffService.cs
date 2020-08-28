using StaffManagment.Models;
using StaffManagment.Models.Entities;
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
        public IEnumerable<District> GetDistricts(int provinceId)
        {
            return context.Districts.Where(e => e._province_id == provinceId);
        }

        public IEnumerable<Province> GetProvinces()
        {
            return context.Provinces;
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
    }
}
