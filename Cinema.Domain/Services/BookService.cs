using Cinema.Domain.Entities;
using Cinema.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Services
{
    public class BookService
    {
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");
        public Purchase GetOne(long id)
        {
            return unitOfWork.Purchases.Get(id);
        }

        public List<Purchase> GetAll()
        {
            return unitOfWork.Purchases.GetAll().ToList();
        }

        public void AddOrUpdatePurchase(Purchase purchase)
        {
            var tickets = purchase.Tickets;

            foreach (var item in tickets)
            {
                unitOfWork.Tickets.AddOrUpdate(item);
            }
            unitOfWork.Purchases.AddOrUpdate(purchase);
            unitOfWork.Save();
        }

        public void RemovePurchase(long id)
        {
            var purchase = unitOfWork.Purchases.Get(id);
            unitOfWork.Purchases.Delete(purchase);
            unitOfWork.Save();
        }

        public List<TicketModel> GetTicketsByTimeSeanceId(long timeSeanceId)
        {
            return unitOfWork.Tickets.GetAll().Where(t => t.TimeSeanceId == timeSeanceId).ToList();
        }

        public long GetLastElId()
        {
            return unitOfWork.Purchases.GetAll().LastOrDefault().Id;
        }
    }
}
