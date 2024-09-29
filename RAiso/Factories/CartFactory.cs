using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factories
{
    public class CartFactory
    {
        public static Cart Create(int userId, int stationeryId, int qty)
        {
            Cart cart = new Cart()
            {
                UserID = userId,
                StationeryID = stationeryId,
                Quantity = qty
            };

            return cart;
        }
    }
}