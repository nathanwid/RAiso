using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factories
{
    public class TransHeaderFactory
    {
        public static TransactionHeader Create(int id, int userId, DateTime date)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                TransactionID = id,
                UserID = userId,
                TransactionDate = date
            };

            return transactionHeader;
        }
    }
}