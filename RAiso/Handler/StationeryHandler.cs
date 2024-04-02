using RAiso.Factory;
using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handler
{
    public class StationeryHandler
    {
        public static List<MsStationery> GetStationeries()
        {
            return StationeryRepository.GetAll();
        }
        public static int GetIdByName(String name)
        {
            MsStationery s = StationeryRepository.GetStationery(name);
            return s.StationeryID;
        }
        public static MsStationery GetStationery(int id) 
        {
            return StationeryRepository.FindStationery(id);
        }
        private static int GenerateID()
        {
            int id = 0;
            MsStationery s = StationeryRepository.GetLastStationery();
            if (s == null)
            {
                id = 1;
            }
            else
            {
                id = s.StationeryID;
                id++;
            }
            return id;
        }
        public static void HandleInsert(String name, int price)
        {
            MsStationery s = StationeryFactory.CreateStationery(GenerateID(), name, price);
            StationeryRepository.InsertStationery(s);
        }
        public static void HandleDelete(int id)
        {
            MsStationery s = StationeryRepository.FindStationery(id);
            StationeryRepository.DeleteStationery(s);
        }
        public static void HandleUpdate(String name, int price, String nameFirst)
        {
            MsStationery s = StationeryRepository.GetStationery(nameFirst);
            StationeryRepository.UpdateStationery(s, name, price);
        }
    }
}