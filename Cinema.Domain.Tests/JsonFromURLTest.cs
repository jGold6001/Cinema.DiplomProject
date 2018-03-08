using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain.Repositories;
using Cinema.Domain.Business;
using Cinema.Domain.Entities;
using System.Diagnostics;

namespace Cinema.Domain.Tests
{
    [TestClass]
    public class JsonFromURLTest
    {
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsCinema");
        

        [TestInitialize]
        public void Init()
        {
           
        }

        [TestMethod]
        public void Get_Person_From_API_Add_And_Delete_To_DB_Test()
        {
            var person = JsonFromURL<Person>.ConvertToObject("http://kino-teatr.ua:8081/services/api/person/1155?apiKey=pol1kh111");
            Trace.WriteLine(person.LastName);
        }
    }
}
