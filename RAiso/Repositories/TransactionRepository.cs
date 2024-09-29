using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repositories
{
    public class TransactionRepository
    {
        private static LocalDatabaseEntities db = DBSingleton.GetInstance();

        public static List<TransactionHeader> GetTransactionsByUser(int id)
        {
            return (from x in db.TransactionHeaders where x.UserID.Equals(id) select x).ToList();
        }

        public static TransactionHeader FindById(int id)
        {
            return (from x in db.TransactionHeaders where x.TransactionID == id select x).FirstOrDefault();
        }

        public static TransactionHeader GetLastTransaction()
        {
            return db.TransactionHeaders.ToList().LastOrDefault();
        }

        public static void CreateOrder(TransactionHeader order)
        {
            db.TransactionHeaders.Add(order);
            db.SaveChanges();
        }

        public static void CreateOrderDetail(List<TransactionDetail> details)
        {
            foreach (var detail in details)
            {
                db.TransactionDetails.Add(detail);
            }
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetTransactions()
        {
            return db.TransactionHeaders.ToList();
        }
    }
}