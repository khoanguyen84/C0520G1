using Microsoft.EntityFrameworkCore;
using PeopleManagement.Models;
using PeopleManagement.Models.Entities;
using PeopleManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly AppDbContext context;

        public PeopleService(AppDbContext context)
        {
            this.context = context;
        }

        public List<District> GetDistricts(int? provinceId)
        {
            if (provinceId.HasValue)
            {
                return context.Districts.Where(e => e._province_id == provinceId).ToList();
            }
            return context.Districts.ToList();
        }

        public List<PeopleView> GetPeople()
        {
            var people = (from p in context.Peoples
                          join ps in context.Provinces on p.ProvinceId equals ps.id
                          join d in context.Districts on p.DistrictId equals d.id
                          join w in context.Wards on p.WardId equals w.id
                          select new PeopleView() {
                              Address = p.Address,
                              DistrictName = $"{d._prefix} {d._name}",
                              Email = p.Email,
                              Fullname = p.Fullname,
                              Id = p.Id,
                              PhoneNumber = p.PhoneNumber,
                              ProvinceName = ps._name,
                              WardName = $"{w._prefix} {w._name}"
                          }).OrderByDescending(e => e.Id).ToList();
            return people;
        }

        public List<Province> GetProvinces()
        {
            return context.Provinces.ToList();
        }

        public List<Ward> GetWards(int? provinceId, int? districtId)
        {
            if (provinceId.HasValue && districtId.HasValue)
            {
                return context.Wards.Where(e => e._province_id == provinceId && e._district_id == districtId).ToList();
            }
            return context.Wards.ToList();
        }

        public int SavePeople(People people)
        {
            context.Peoples.Add(people);
            return context.SaveChanges();
        }
    }
}
