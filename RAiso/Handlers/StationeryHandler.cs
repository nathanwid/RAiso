using RAiso.Factories;
using RAiso.Model;
using RAiso.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handlers
{
    public class StationeryHandler
    {
        public static int GenerateID()
        {
            MsStationery lastStationery = StationeryRepository.GetLastStationery();

            if (lastStationery == null)
            {
                return 1;
            }
            else
            {
                int lastId = lastStationery.StationeryID;
                int newId = lastId + 1;
                return newId;
            }
        }

        public static Boolean Insert(int id, string name, int price)
        {
            MsStationery checkName = StationeryRepository.FindByName(name);

            if (checkName != null)
            {
                return false;
            }
            else
            {
                MsStationery stationery = StationeryFactory.Create(id, name, price);
                StationeryRepository.AddStationery(stationery);
                return true;
            }
        }

        public static List<MsStationery> GetAllStationery()
        {
            return StationeryRepository.GetAllStationery();
        }

        public static MsStationery FindById(int id)
        {
            return StationeryRepository.FindById(id);
        }

        public static Boolean Update(int id, string name, int price)
        {
            MsStationery stationery = FindById(id);
            MsStationery checkName = StationeryRepository.FindByName(name);

            if (checkName == null || checkName.StationeryID == stationery.StationeryID)
            {
                stationery.StationeryName = name;
                stationery.StationeryPrice = price;
                StationeryRepository.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public static void DeleteById(int id)
        {
            StationeryRepository.DeleteById(id);
        }

        public static MsStationery CheckStationery(int id)
        {
            MsStationery x = FindById(id);

            if (x != null) return x;
            else return null;
        }
    }
}