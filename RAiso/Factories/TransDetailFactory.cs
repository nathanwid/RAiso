using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factories
{
    public class TransDetailFactory
    {
        public static TransactionDetail Create(int id, int stationeryId, int qty)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = id,
                StationeryID = stationeryId,
                Quantity = qty
            };

            return transactionDetail;
        }
    }
}