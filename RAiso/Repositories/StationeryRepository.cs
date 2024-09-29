using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repositories
{
    public class StationeryRepository
    {
        private static LocalDatabaseEntities db = DBSingleton.GetInstance();

        public static void AddStationery(MsStationery stationery)
        {
            db.MsStationeries.Add(stationery);
            db.SaveChanges();
        }

        public static MsStationery GetLastStationery()
        {
            return db.MsStationeries.ToList().LastOrDefault();
        }

        public static MsStationery FindByName(string name)
        {
            return (from x in db.MsStationeries where x.StationeryName == name select x).FirstOrDefault();
        }

        public static List<MsStationery> GetAllStationery()
        {
            return (from x in db.MsStationeries select x).ToList();
        }

        public static MsStationery FindById(int id)
        {
            return (from x in db.MsStationeries where x.StationeryID == id select x).FirstOrDefault();  
        }

        public static void SaveChanges()
        {
            db.SaveChanges();
        }

        public static void DeleteById(int id)
        {
            MsStationery stationery = FindById(id);
            db.MsStationeries.Remove(stationery);
            db.SaveChanges();
        }
    }
}