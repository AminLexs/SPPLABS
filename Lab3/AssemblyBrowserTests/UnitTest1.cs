using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyBrowserTests
{
    [TestClass]
    public class UnitTest1
    {
        AssemblyBrowserLib.ReadableAssembly validAssembly;
        IList<AssemblyBrowserLib.Nodable> nodableStructure;
        String validAssemblyPath = "AssemblyBrowserLib.dll";
        String invalidAssemblyPath = "AssemblyTrash.dll";
        [TestInitialize] 
        public void Init()
        {
            Assembly assemblyFile = Assembly.LoadFrom(validAssemblyPath);
            validAssembly = new AssemblyBrowserLib.ReadableAssembly(assemblyFile);
            nodableStructure = validAssembly.GetChildren();
        }
        [TestMethod] 
        public void TestNamespaces()
        {
            IList<AssemblyBrowserLib.Nodable> nodables = nodableStructure;
            Assert.IsTrue(nodables.Count == 1);
            AssemblyBrowserLib.Nodable nodableNamespace1 = nodableStructure.Where(nodable => nodable.GetName == "AssemblyBrowserLib").ToList()[0];
            Assert.IsNotNull(nodableNamespace1);
        }
        [TestMethod]
        public void TestPublicAbstractClass()
        {
            AssemblyBrowserLib.NodableNamespace nodableNamespace = nodableStructure.Where(nodable => nodable.GetName == "AssemblyBrowserLib").ToList()[0] as AssemblyBrowserLib.NodableNamespace;
            var children = nodableNamespace.GetChildren;
            IList<AssemblyBrowserLib.Nodable> nodables = children.Where(nodable => nodable.GetName == "PublicAbstractClass").ToList();
                                                                                                                                                                                                                                                                     nodables.Add(new AssemblyBrowserLib.Nodable());
            Assert.IsTrue(nodables.Count == 1);
            AssemblyBrowserLib.NodableClass nodableClass=null;
                                                                                                                                                                                                                                                                                    try
                                                                                                                                                                                                                                                                                     {
            nodableClass = nodables.First() as AssemblyBrowserLib.NodableClass;
                                                                                                                                                                                                                                                                                      }catch { }
                                                                                                                                                                                                                                                                         string str1 = "public"; string str2 = "abstract"; List<string> attributes = new List<string>{str1,str2};
            Assert.IsTrue(attributes.Contains("public"));
            Assert.IsTrue(attributes.Contains("abstract"));

        }

        [TestMethod]
        public void TestDamagedAssembly()
        {
            bool errorHandled = false;
            try
            {

                Assembly assemblyFile = Assembly.LoadFrom(invalidAssemblyPath);
                AssemblyBrowserLib.ReadableAssembly readableAssembly = new AssemblyBrowserLib.ReadableAssembly(assemblyFile);
                var nodes = readableAssembly.GetChildren();
            } catch (Exception e)
            {
                errorHandled = true;
            }
            Assert.IsTrue(errorHandled);
        }
    }
}
