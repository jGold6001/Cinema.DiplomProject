using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain.Business;
using System.Diagnostics;
using System.Collections.Generic;
using Cinema.Domain.Entities;

namespace Cinema.Domain.Tests
{
    [TestClass]
    public class PriceParserTest
    {
        [TestMethod]
        public void Parse_Num_dash_Num_Test()
        {
            var str = "100-345";
            var nums = PriceParser.Parse(str);

            foreach (var item in nums)
            {
                Trace.WriteLine(item);
            }
        }

        [TestMethod]
        public void Parse_Num_Test()
        {
            var str = "100";
            var numsActual = PriceParser.Parse(str);
            var numsExpect = new List<int>() { 100};

            for (int i = 0; i < numsActual.Count; i++)
            {
                Trace.WriteLine("actual: " + numsActual[i]);
                Trace.WriteLine("expect: " + numsExpect[i]);
                Trace.WriteLine("-----------");
                Assert.AreEqual(numsActual[i], numsExpect[i]);
            }
        }

        [TestMethod]
        public void Parse_Num_Num_Num_Test()
        {
            var str = "100 456 1234";
            var numsActual = PriceParser.Parse(str);
            var numsExpect = new List<int>() { 100, 456, 1234 };

            for (int i = 0; i < 3; i++)
            {
                Trace.WriteLine("actual: " + numsActual[i]);
                Trace.WriteLine("expect: " + numsExpect[i]);
                Trace.WriteLine("-----------");
                Assert.AreEqual(numsActual[i], numsExpect[i]);
            }
        }

        [TestMethod]
        public void Parse_Num_comma_Num_comma_Num_Test()
        {
            var str = "100,456,1234";
            var numsActual = PriceParser.Parse(str);
            var numsExpect = new List<int>() {100, 456, 1234 };

            for (int i = 0; i < 3; i++)
            {
                Trace.WriteLine("actual: " + numsActual[i]);               
                Trace.WriteLine("expect: " + numsExpect[i]);
                Trace.WriteLine("-----------");
                Assert.AreEqual(numsActual[i], numsExpect[i]);
            }         
        }

        [TestMethod]
        public void Florence_Parse_Num_dash_Num_Test()
        {
            var str = "70-90";
            var pricesActual = PriceFormer.Prices(str);
            var pricesExpect = new List<Price>() {
                new Price(1, 70),
                new Price(2, 75),
                new Price(3, 85),
                new Price(4, 90)
            };


            for (int i = 0; i < pricesActual.Count; i++)
            {
                Trace.WriteLine($"actual: {pricesActual[i].Type} - {pricesActual[i].Money} UAH");
                Trace.WriteLine($"expect: {pricesExpect[i].Type} - {pricesExpect[i].Money} UAH");
                Trace.WriteLine("-----------");
                Assert.AreEqual(pricesActual[i].Money, pricesExpect[i].Money);
            }
        }


        [TestMethod]
        public void Florence_Parse_Num_dash_Num_Test2()
        {
            var str = "65-85";
            var pricesActual = PriceFormer.Prices(str);
            var pricesExpect = new List<Price>() {
                new Price(1, 65),
                new Price(2, 70),
                new Price(3, 75),
                new Price(4, 85)
            };

            for (int i = 0; i < pricesActual.Count; i++)
            {
                Trace.WriteLine($"actual: {pricesActual[i].Type} - {pricesActual[i].Money} UAH");
                Trace.WriteLine($"expect: {pricesExpect[i].Type} - {pricesExpect[i].Money} UAH");
                Trace.WriteLine("-----------");
                Assert.AreEqual(pricesActual[i].Money, pricesExpect[i].Money);
            }
        }

        [TestMethod]
        public void Boomer_Parse_Num_Num_Num_Test()
        {
            var str = "45 55 65";
            var prices = PriceFormer.Prices(str);

            var pricesActual = PriceFormer.Prices(str);
            var pricesExpect = new List<Price>() {
                new Price(1, 45),
                new Price(2, 55),
                new Price(3, 65),              
            };

            for (int i = 0; i < pricesActual.Count; i++)
            {
                Trace.WriteLine($"actual: {pricesActual[i].Type} - {pricesActual[i].Money} UAH");
                Trace.WriteLine($"expect: {pricesExpect[i].Type} - {pricesExpect[i].Money} UAH");
                Trace.WriteLine("-----------");
                Assert.AreEqual(pricesActual[i].Money, pricesExpect[i].Money);
            }
        }


        [TestMethod]
        public void Florence_Parse_isNotFactNum_Test()
        {
            var str = "23-12";
            var prices = PriceFormer.Prices(str);

            Assert.IsNull(prices);

        }

        [TestMethod]
        public void Parse_isNotNumbers_Test()
        {
            var str = "feffefef";
            var prices = PriceFormer.Prices(str);

            Assert.IsNull(prices);

        }

        [TestMethod]
        public void Parse_isEmptyString_Test()
        {
            var str = "";
            var prices = PriceFormer.Prices(str);

            Assert.IsNull(prices);

        }

    }
}
