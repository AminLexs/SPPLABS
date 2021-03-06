﻿using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_4_Test_Generator;
using System.Collections.Generic;

namespace TestsForTestGenerator
{
    [TestClass]
    public class Testing
    {
        string test1;
        string test2;

        [TestInitialize]
        public void Init()
        {
            String dirPath = @"TestDirectory";
            int simultFileLoadLimit = 2;
            int simultTasksLimit = 2;
            int simultFileWriteLimit = 2;
           
            TestGeneratorHandler tdh = new TestGeneratorHandler(simultTasksLimit);
            tdh.GenerateTestsForDir(dirPath, simultFileLoadLimit, simultTasksLimit, simultFileWriteLimit).Wait();

            test1 = File.ReadAllText("TestDirectory\\Generated Tests\\Program_Test.cs");
            test2 = File.ReadAllText("TestDirectory\\Generated Tests\\TestGeneratorHandler_Test.cs");
        }

        [TestMethod]
        public void AmountOfGeneratedTests()
        {
            var pluginFiles = Directory.GetFiles("TestDirectory\\Generated Tests", "*.cs");
            Assert.AreEqual(3, pluginFiles.Length);
        }

        [TestMethod]
        public void NamespaceNameCheck()
        {

            bool flag = test1.Contains("namespace Lab_4_Test_Generator.Test") && test2.Contains("namespace Lab_4_Test_Generator.Test");
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void UsingsNamesCheck()
        {
            string[] expectedUsingsNames = { "using System", "using Microsoft.VisualStudio.TestTools.UnitTesting", "using Lab_4_Test_Generator"};
            foreach (var str in expectedUsingsNames) {
                if (!test1.Contains(str))
                {
                    Assert.Fail($"Wrong name: {str}\n");
                }       
            }
        }

        [TestMethod]
        public void ClassNameCheck()
        {
            int count = 0, index = 0;
            while ((index = test1.IndexOf("class", index) + 1) != 0) count++;
            Assert.AreEqual(1, count);
            bool flag = test1.Contains("public class Program");
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void MethodsNamesCheck()
        {      
            int count = 0, index = 0;
            while ((index = test2.IndexOf("[Test]", index) + 1) != 0) count++;
            Assert.AreEqual(3, count);
            string[] expectedMethodsNames = { "GenerateTestsForClassTest", "GenerateTestsForFileTest", "GenerateTestsForDirTest" };
            foreach (var str in expectedMethodsNames)
            {
                if (!test2.Contains(str))
                {
                    Assert.Fail($"Wrong method name: {str}\n");
                }
            }
        }

        [TestMethod]
        public void MethodBodyCheck()
        {
            int count = 0, index = 0;
            while ((index = test2.IndexOf("Assert.Fail(\"autogenerated\");", index) + 1) != 0) count++;
            Assert.AreEqual(3, count);
        }
    }
}
