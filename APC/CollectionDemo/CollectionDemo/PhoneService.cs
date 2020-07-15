using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionDemo
{
    class PhoneService
    {
        public SortedList PhoneList = new SortedList();
        public void Add(Contact contact)
        {
            PhoneList.Add(contact.Name, contact);
        }

        public void Show()
        {
            Console.WriteLine("Name\t\tPhone number");
            foreach(var key in PhoneList.Keys)
            {
                Console.WriteLine(PhoneList[key].ToString());
            }
        }
    }
}
