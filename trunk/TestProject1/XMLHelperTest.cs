using Project423;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for XMLHelperTest and is intended
    ///to contain all XMLHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XMLHelperTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for classToXml
        ///</summary>
        [TestMethod()]
        public void classToXmlTest_1()
        {
            Configuration configuration = new Configuration()
            {
                ParentID = 1,
                DeviceId = 2,
                ConfigurationType = EnumConfigurationType.Folder,
                RegisterGroup = null
            };
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = XMLHelper.objectToXml(configuration);

            Debug.WriteLine(actual);

//            Assert.AreEqual(expected, actual);

        }

        String xmlText = @"<?xml version=""1.0"" encoding=""utf-16""?>
                              <Configuration xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                              <DeviceId>2</DeviceId>
                                <ParentID>1</ParentID>
                                <ConfigurationType>RegisterGroup</ConfigurationType>
                                <RegisterGroup>
                                    <IpAddress>192.168.8.45</IpAddress>
                                    <Port>8080</Port>
                                    <RegisterValueList> 
                                        <RegisterValue>
                                        <Address>123</Address>
                                        <Name>reg1</Name>
                                        <Value>2</Value>
                                      </RegisterValue>
                                      <RegisterValue>
                                        <Address>234</Address>
                                        <Name>reg2</Name>
                                        <Value>4</Value>
                                      </RegisterValue>
                                    </RegisterValueList>
                                  </RegisterGroup>
                                </Configuration>";


        /// <summary>
        ///A test for classToXml
        ///</summary>
        [TestMethod()]
        public void classToXmlTest_2()
        {
            Configuration configuration = new Configuration()
            {
                ParentID = 1,
                DeviceId = 2,
                ConfigurationType = EnumConfigurationType.RegisterGroup,
                RegisterGroup = new RegisterGroup()
                    {
                         IpAddress = "192.168.8.45",
                         Port = 8080,
                         RegisterValueList = new List<RegisterValue>()
                            {
                                 new RegisterValue() { Address=123, Name="reg1", Value=2}, new RegisterValue() { Address=234, Name= "reg2", Value=4}
                            }
                    }
            };

            string expected = xmlText;
            string actual = XMLHelper.objectToXml(configuration);
            //Debug.WriteLine(actual);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for xmlToClass
        ///</summary>
        [TestMethod()]
        public void xmlToClassTest_1()
        {

            Configuration expected = new Configuration()
                                    {
                                        ParentID = 1,
                                        DeviceId = 2,
                                        ConfigurationType = EnumConfigurationType.RegisterGroup,
                                        RegisterGroup = new RegisterGroup()
                                        {
                                            IpAddress = "192.168.8.45",
                                            Port = 8080,
                                            RegisterValueList = new List<RegisterValue>()
                                                    {
                                                         new RegisterValue() { Address=123, Name="reg1", Value=2}, new RegisterValue() { Address=234, Name= "reg2", Value=4}
                                                    }
                                        }
                                    };
            Configuration actual = XMLHelper.xmlToObject(xmlText);
            Assert.AreEqual(expected, actual);
        }
    }
}
