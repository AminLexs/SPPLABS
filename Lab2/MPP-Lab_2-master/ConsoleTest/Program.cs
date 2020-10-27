using Faker;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker.Faker faker = new Faker.Faker();
            Useless useless = faker.Create<Useless>();
            Console.WriteLine(useless.text);
            Console.WriteLine(useless.usefull);
        }
    }

    class Useless
    {
        public string Welcome { get; }
        public List<Usefull> data;
        public Uri shit;
        public string text; 
        public int number;
        public DateTime date;
        public Usefull usefull;
    }

    class Usefull
    {
        public Usefull(double point)
        {
            floatingPoint = point;
        }
        
        public Usefull _usefull;
        private double floatingPoint;
    }

}