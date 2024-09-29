using RAiso.Handlers;
using RAiso.Model;
using RAiso.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RAiso.Controllers
{
    public class CartController
    {
        public static String AddToCart(int userId, int stationeryId, string qty)
        {
            if (qty == "")
            {
                return "Quantity must be filled";
            }
            else if (!Regex.IsMatch(qty, @"^-?\d+(\.\d*)?$"))
            {
                return "Quantity must be numeric";
            }
            else if (Convert.ToInt32(qty) < 1)
            {
                return "The quantity must be at least 1";
            }
            else
            {
                int quantity = int.Parse(qty);
                Boolean response = CartHandler.AddToCart(userId, stationeryId, quantity);
                if (response == true)
                {
                    return "Success";
                }
                else
                {
                    return "You've added this item to your cart";
                }
            }
        }

        public static List<Cart> GetCarts(int userId)
        {
            return CartHandler.GetCarts(userId);
        }

        public static Cart GetCart(int id, int stationeryId)
        {
            return CartHandler.GetCart(id, stationeryId);
        }

        public static String Update(int userId, int stationeryId, string qty)
        {
            if (qty == "")
            {
                return "Quantity must be filled";
            }
            else if (!Regex.IsMatch(qty, @"^-?\d+(\.\d*)?$"))
            {
                return "Quantity must be numeric";
            }
            else if (Convert.ToInt32(qty) < 1)
            {
                return "The quantity must be at least 1";
            }
            else
            {
                int quantity = int.Parse(qty);
                Boolean response = CartHandler.Update(userId, stationeryId, quantity);
                if (response == true)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
        }

        public static void DeleteCartItem(int userId, int stationeryId)
        {
            CartHandler.DeleteCartItem(userId, stationeryId);
        }
    }
}