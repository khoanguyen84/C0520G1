using System;

namespace AbstractInterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Animal animal = new Animal();
            //IFlyable flyable = new IFlyable();
        }
    }

    abstract class Animal
    {
        public Animal()
        {

        }
        internal abstract string Move();
        public string Info()
        {
            return "";
        }
    }

    class Fish : Animal
    {
        internal override string Move()
        {
            return "swimming";
        }
    }

    class Bird : Animal, IFlyable, IEatale
    {
        internal override string Move()
        {
            throw new NotImplementedException();
        }
        public string CanFly()
        {
            throw new NotImplementedException();
        }

        public string HowCanEat()
        {
            throw new NotImplementedException();
        }
    }

    abstract class Car
    {
        public string Info()
        {
            return "";
        }
    }

    interface IFlyable
    {
        string CanFly();
    }

    interface IEatale
    {
        string HowCanEat();
    }
}
