using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionDemo
{
    class PhoneManagement
    {
        public static PhoneService phoneService = new PhoneService();
        public static void Main()
        {
            phoneService.Add(new Contact()
            {
                Name = "My",
                PhoneNumber = "113"
            });
            phoneService.Add(new Contact()
            {
                Name = "An",
                PhoneNumber = "114"
            });
            phoneService.Add(new Contact()
            {
                Name = "Nhan",
                PhoneNumber = "115"
            });

            phoneService.Show();
        }
    }
}
