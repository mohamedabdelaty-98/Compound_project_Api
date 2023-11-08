using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;

namespace DataAccessLayer.Reposatories
{
    public class BuildingRepo : GenericReposatory<Building>, IBuilding
    {
        private readonly Context _context;
        public BuildingRepo(Context context) :base(context)
        {
            _context = context;
        }

        public List<Building> FilterBasedOnUnitFloor(int num,int compoundid)
        {
            return _context.buildings.Where(building => building.CompoundId== compoundid
            && building.Units.Any(u => u.Floor == num && u.status == Status.active)).ToList();
        }

        public List<Building> FilterBasedOnUnitNumBedRooms(int num,int compoundid)
        {

            //return _context.buildings.Where(building => building.Units.Any(u => u.unitComponents.Any(uC => uC.NumberComponent == num && uC.component.Name =="Bed"))).ToList();
            return _context.buildings.Where(building =>building.CompoundId==compoundid && 
            building.Units.Any(u => u.NumberOfBedrooms == num && u.status== Status.active)).ToList();

        }
        public List<Building> FilterBasedOnUnitareaGreaterthan(int num, int compoundid)
        {
            return _context.buildings.Where(building => building.CompoundId == compoundid &&
            building.Units.Any(u => u.Area >= num && u.status == Status.active)).ToList();
        }
        public List<Building> FilterBasedOnUnitareaLessthan(int num, int compoundid)
        {
            return _context.buildings.Where(building => building.CompoundId == compoundid &&
            building.Units.Any(u => u.Area < num && u.status == Status.active)).ToList();
        }
        public List<Building> FilterBasedOnUnitStatus(int num)
        {
            return _context.buildings.Where(building =>building.CompoundId==num
            &&building.Units.Any(u => u.status == Status.active)).ToList();
        }
        public List<Building> FilterBasedOnBuildingNumber(int buildingnumber,int compoundnumber)
        {
            return _context.buildings.Where(b=>b.BulidingNumber== buildingnumber&&
            b.CompoundId==compoundnumber).ToList();
        }
        public List<Building> FilterByCompoundNumber(int num)
        {
            //List<Unit> units = _context.units.Where(u => u.status == Status.active &&
            //u.building.CompoundId == num).ToList();
            //return units.Select(b => b.building).ToList();
            return _context.buildings.Where(building => building.CompoundId == num).ToList();
        }

        public List<Building> FilterByStatus()
        {
            return _context.buildings.Where(building=>building.status == Status.active).ToList();
        }
        public List<int> getBuildings(int compoundnunm)
        {
            List<Unit> units = _context.units.Where(u => u.status == Status.active &&
            u.building.CompoundId == compoundnunm).ToList();
            return units.Select(b => b.building.BulidingNumber).ToList();
        }
    }
}
