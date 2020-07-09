using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneManagement
{
    class PhoneBook : Phone
    {
        public Contact[] PhoneList = new Contact[3];


        public PhoneBook()
        {
            PhoneList[0] = new Contact()
            {
                Name = "Nhan",
                PhoneNumber = "12345"
            };
            PhoneList[1] = new Contact()
            {
                Name = "Tung",
                PhoneNumber = "78906"
            };
            PhoneList[2] = new Contact()
            {
                Name = "Hieu",
                PhoneNumber = "345678"
            };
        }

        public override void InsertPhone(string name, string phone)
        {
            var pos = FindName(name, out string phoneNumber);
           
            if (pos == -1)
            {
                var contact = new Contact()
                {
                    Name = name,
                    PhoneNumber = phone
                };
                Array.Resize(ref PhoneList, PhoneList.Length + 1);
                PhoneList[PhoneList.Length - 1] = contact;
            }
            else
            {
                if(PhoneList[pos].PhoneNumber != phone)
                {
                    PhoneList[pos].PhoneNumber += $" : {phone}";
                }
            }
        }

        public override void RemovePhone(string name)
        {
            var pos = FindName(name, out string phoneNumber);
            if(pos != -1)
            {
                for(int i = pos; i< PhoneList.Length - 1; i++)
                {
                    PhoneList[i] = PhoneList[i + 1];
                }
                Array.Resize(ref PhoneList, PhoneList.Length - 1);
            }
        }

        public override void SearhPhone(string name)
        {
            for (int i = 0; i < PhoneList.Length; i++)
            {
                if (PhoneList[i].Name == name)
                {
                    Console.WriteLine(PhoneList[i].ToString());
                }
            }
        }

        public override void Sort()
        {
            throw new NotImplementedException();
        }

        public override void UpdatePhone(string name, string newPhone)
        {
            var pos = FindName(name, out string phoneNumber);

            if (pos != -1)
            {
                PhoneList[pos].PhoneNumber = newPhone;
            }
        }

        public void Show()
        {
            foreach(var contact in PhoneList)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        private int FindName(string name, out string phoneNumber)
        {
            for(int i=0; i< PhoneList.Length; i++)
            {
                if(PhoneList[i].Name == name)
                {
                    phoneNumber = PhoneList[i].PhoneNumber;
                    return  i;
                }
            }
            phoneNumber = string.Empty;
            return -1;
        }

        private Contact FindContact(string name)
        {
            foreach(var contact in PhoneList)
            {
                if(contact.Name == name)
                {
                    return contact;
                }
            }
            return new Contact();
        }
    }
}
