using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeDemo
{
    /// <summary>
    /// CRUD Student 
    /// </summary>
    class Student
    {
        #region properties
        public string FullName { get; set; }
        public int StudentId { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        #endregion

        #region Contructors
        public Student()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        public Student(string fn)
        {
            FullName = fn;
        }

        /// <summary>
        /// allow create new student with 3 parameter: fullname, gender and address
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="gender"></param>
        /// <param name="address"></param>
        public Student(string fn, bool gender, string address)
        {
            FullName = fn;
            Gender = gender;
            Address = address;
        }
        #endregion

        #region public
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Fullname: {FullName}";
        }

        /// <summary>
        /// this function allow find out student with name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>if returns -1 then not found orthewise found</returns>
        public int FindName(string name)
        {
            return 1;
        }

        #endregion

        #region private

        private string FormatFullName()
        {
            FullName = FullName.Trim();
            FullName = FullName.ToUpper();
            FullName = $"{FullName}_{Operand.Addition}";
            return FullName;
        }

        #endregion
    }
}
