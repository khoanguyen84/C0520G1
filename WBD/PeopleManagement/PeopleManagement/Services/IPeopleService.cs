using PeopleManagement.Models.Entities;
using PeopleManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Services
{
    public interface IPeopleService
    {
        List<Province> GetProvinces();
        List<District> GetDistricts(int? provinceId);
        List<Ward> GetWards(int? provinceId, int? districtId);
        int SavePeople(People people);
        List<PeopleView> GetPeople();
    }
}
