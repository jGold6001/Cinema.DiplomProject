using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Cinema.Domain.EF;
using Cinema.Domain.Entities;

namespace Cinema.Domain.Repositories
{
    public class EFUnitOfWork 
    {
        private DbContext db;

        private TestRepository testRepository;
        private PersonRepository personRepository;
        
        public EFUnitOfWork(string connectionString)
        {
            db = new CotsContext(connectionString);
        }
        public Repository<Test> Testes
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(db);
                return testRepository;
            }
        }

        public Repository<Person> Persons
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(db);
                return personRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
