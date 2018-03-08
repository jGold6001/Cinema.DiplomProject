using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain.Services;
using Cinema.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity;
using Cinema.Domain.Repositories;
using Cinema.Domain.EF;
using System.Linq;
using Cinema.Domain.Business;

namespace Cinema.Domain.Tests
{
    [TestClass]
    public class TestServiceTest
    {
        TestService testService;
        
        [TestInitialize]
        public void Init()
        {
            testService = new TestService();          
        }

        [TestMethod]
        public void AddOrUpdate_GetAll_Delete_TestClass()
        {
            Test test = new Test()
            {
                Name = "oblect_1"
            };

            testService.AddOrUpdateTest(test);

            Assert.AreEqual(testService.GetAll().Where(t => t.Name == test.Name).FirstOrDefault().Name, test.Name); 

            foreach (var item in testService.GetAll().ToList())
                testService.Delete(item.Id);

        }


        [TestMethod]
        public void AddOrUpdate_GetAll_Delete_CinemaAPI()
        {
            var data = JsonFromURL<TestJsonModels>.ConvertToObject(@"http://kino-teatr.ua:8081/services/api/genres?apiKey=pol1kh111");
            Test test = new Test()
            {
                Id = data.Models[0].Id,
                Name = data.Models[0].Name
            };

            testService.AddOrUpdateTest(test);

            Assert.AreEqual(testService.GetOne(test.Id).Name, test.Name);

            foreach (var item in testService.GetAll().ToList())
                testService.Delete(item.Id);
        }
    }
}
