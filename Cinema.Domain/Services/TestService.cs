using Cinema.Domain.EF;
using Cinema.Domain.Entities;
using Cinema.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Services
{
    public class TestService
    {
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");
        TestRepository testRepository;
        public TestService()
        {
            testRepository = unitOfWork.Testes as TestRepository;
        }
        public void AddOrUpdateTest(Test test)
        {
            testRepository.AddOrUpdate(test);
            unitOfWork.Save();
        }

        public void Delete(long id)
        {
            var obj = testRepository.Get(id);
            testRepository.Delete(obj);
            unitOfWork.Save();
        }
      
        public IEnumerable<Test> GetAll()
        {
            return testRepository.GetAll();
        }

        public Test GetOne(long id)
        {
            return testRepository.Get(id);
        }
    }
}
