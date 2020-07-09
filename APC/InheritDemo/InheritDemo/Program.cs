using System;

namespace InheritDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student son = new Student()
            //{
            //    StudentCode = "1234",
            //    Email = "son.nguyen@codegym.vn",
            //    Age = 18,
            //    Fullname = "Son Nguyen",
            //    Gender = true
            //};

            Student tung = new Student("Tung", 18, true, "tung.nguyen@codegym,vn", "12345");

            Console.WriteLine(tung.ToString());
            //Console.WriteLine(son.ShowProfile());

            Person person1 = new Person();
            
            //Console.WriteLine( person1.ToString());
            //Person person2 = new Person("Hieu", 18, true);
            //Console.WriteLine(person1.Greeting());
            //Console.WriteLine(person2.Greeting());

            MathTest math = new MathTest();
            math.Sum();
        }
    }


    class Person : Object
    {
        public string Fullname { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        protected string phoneNumber { get; set; }

        public Person()
        {

        }

        //public Person(string fn, int age, bool gender) 
        //{
        //    Fullname = fn;
        //    Age = age;
        //    Gender = gender;
        //}

        public Person(string Fullname, int Age, bool Gender)
        {
            this.Fullname = Fullname;
            this.Age = Age;
            this.Gender = Gender;
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => phoneNumber = value;
        }

        public override string ToString()
        {
            return $"Fullname: {Fullname}, Age: {Age}, Gender: { (Gender ? "Male" : "Female") }";
        }

        //public virtual string Greeting()
        //{
        //    return $"Fullname: {Fullname}, Age: {Age}, Gender: { (Gender ? "Male" : "Female") }";
        //}
    }

    class Student : Person
    {
        public Student()
        {

        }

        public Student(string fn, int age, bool gender, string email, string stdCode) : base(fn, age, gender)
        {
            Email = email;
            StudentCode = stdCode;
        }
        public string Email { get; set; }
        public string StudentCode { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, Email: {Email}, Student code: {StudentCode}";
        }
        //public string ShowProfile()
        //{
        //    return $"Fullname: {Fullname}, Age: {Age}, Gender: { (Gender ? "Male" : "Female")}," +
        //            $" Email: {Email}, Student code: {StudentCode}";
        //}
    }

    
    class MathTest
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public int Sum()
        {
            return Number1 + Number2;
        }

        public int Sum(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Sum(double n1, double n2)
        {
            return (int)3.4 + (int)6.5;
        }
    }


    class MyRandom : Random
    {

    }

    class A
    {
        public virtual string AM()
        {
            return "AM";
        }
    }

    class B : A
    {
        public sealed override string AM()
        {
            return "BM";
        }
    }

    class C : B
    {
    }


    class Aminal
    {

    }

    class Dog : Aminal
    {

    }

    class Fish : Aminal
    {

    }

    //class SpiderMan : Person, Aminal
    //{

    //}
}
