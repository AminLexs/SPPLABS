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
            Foo foo = faker.Create<Foo>();
            Console.WriteLine("text1="+foo.text);
            Console.WriteLine("number1=" + foo.number);
            Console.WriteLine("date1=" + foo.date.Date);
            Console.WriteLine("foo1.bar.floatingPoint=" + foo.bar.floatingPoint);
            Console.WriteLine("foo1.data[0].floatingPoint=" + foo.data[0].floatingPoint);
            Console.WriteLine();
            Foo foo2 = faker.Create<Foo>();
            Console.WriteLine("text2=" + foo2.text);
            Console.WriteLine("number2=" + foo2.number);
            Console.WriteLine("date2=" + foo2.date);
            Console.WriteLine("foo2.bar.floatingPoint=" + foo2.bar.floatingPoint);
            Console.WriteLine("foo2.data[0].floatingPoint=" + foo2.data[0].floatingPoint);
        }
    }

    class Foo
    {
        public List<Bar> data;
        public string text;
        public int number;
        public DateTime date;
        public Bar bar;
   
    }

    class Bar
    {
        public Bar(double point)
        {
            floatingPoint = point;
        }

        public Bar bar;
        public double floatingPoint;
    }

}