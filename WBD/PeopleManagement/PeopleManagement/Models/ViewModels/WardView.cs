using PeopleManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Models.ViewModels
{
    public class WardView : Ward
    {
        public string WardName => $"{_prefix} {_name}";
    }
}
