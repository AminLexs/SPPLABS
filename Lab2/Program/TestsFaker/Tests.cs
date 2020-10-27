using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
namespace TestsFaker
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test1()
        {
            PluginService.PluginService pluginService = new PluginService.PluginService();

            Assert.IsTrue(pluginService.Plugins.Count==4);
        }
        [TestMethod]
        public void Test2()
        {
            Faker.Faker faker = new Faker.Faker();
            try
            { Foo foo1 = faker.Create<Foo>();
                Assert.IsTrue(foo1.uri == null);
            } catch { Assert.Fail("ќшибка при обработке типа, который не €вл€ютс€ DTO, и дл€ которых нет генератора"); }
           
        }
        [TestMethod]
        public void Test3()
        {
            Faker.Faker faker = new Faker.Faker();
            Foo foo1 = faker.Create<Foo>();
            Foo foo2 = faker.Create<Foo>();
            Console.WriteLine(foo1.number);
            Console.WriteLine(foo2.number);
            Console.WriteLine(foo1.text);
            Console.WriteLine(foo2.text);
            Console.WriteLine(foo1.date);
            Console.WriteLine(foo2.date);
            Assert.IsTrue(foo1.number != foo2.number && foo1.text != foo2.text && foo1.date != foo2.date);
        }
    }
    class Foo
    {
        public string Welcome { get; }
        public List<Bar> data;
        public string text;
        public Uri uri;
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
        private double floatingPoint;
    }
}
