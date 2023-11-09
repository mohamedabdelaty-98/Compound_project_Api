using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;

namespace DataAccessLayer.Reposatories
{
    public class UnitRepo : GenericReposatory<Unit>,IUnit
    {
        private readonly Context context;

        public UnitRepo(Context context) : base(context)
        {
            this.context = context;
        }

        public List<Unit> FilterByBuildingNumber(int num)
        {

            return context.units.Where(u => u.status == Status.active && 
            u.building.BulidingNumber == num).ToList();
             
        }

        public List<Unit> FilterByNumOfFloor(int num, int compoundid)
        {
            return context.units.Where(u => u.status == Status.active &&
            u.Floor==num&&u.building.CompoundId==compoundid).ToList();
        }

        public List<Unit> FilterByNumberOfRoom(int num)
        {
            return context.units.Where(u => u.status == Status.active &&
            u.NumberOfBedrooms==num).ToList(); ;
        }

        public List<Unit> FilterByStatus()
        {
            return context.units.Where(u=>u.status==Status.active).ToList();
        }

        public List<Unit> FilterByAll(int FloorNum, int BuildingNum, int NumOfRoom)
        {
           
            return context.units.Where(u => u.status == Status.active &&
            u.Floor==FloorNum && u.building.BulidingNumber==BuildingNum
            && u.NumberOfBedrooms==NumOfRoom).ToList();
            
        }
        public List<int> getFloors(int compoundnunm)
        {
            List<Unit> units= context.units.Where(u => u.status == Status.active &&
            u.building.CompoundId==compoundnunm).ToList();
            return units.Select(f => f.Floor).Distinct().ToList();
        }
        public List<int> getBedroomNumber(int compoundnunm)
        {
            List<Unit> units = context.units.Where(u => u.status == Status.active &&
            u.building.CompoundId == compoundnunm).ToList();
            return units.Select(f => f.NumberOfBedrooms).Distinct().ToList();
        }


    }
}
