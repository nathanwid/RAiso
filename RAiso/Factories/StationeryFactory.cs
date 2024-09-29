using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factories
{
    public class StationeryFactory
    {
        public static MsStationery Create(int id, string name, int price)
        {
            MsStationery stationery = new MsStationery()
            {
                StationeryID = id,
                StationeryName = name,
                StationeryPrice = price
            };

            return stationery;
        }
    }
}