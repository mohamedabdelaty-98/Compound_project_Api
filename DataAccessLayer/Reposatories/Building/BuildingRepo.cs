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

        public List<Building> FilterBasedOnUnitFloor(int num)
        {
            return _context.buildings.Where(building => building.Units.Any(u => u.Floor == num && u.status == Status.active)).ToList();
        }

        public List<Building> FilterBasedOnUnitNumBedRooms(int num)
        {

            //return _context.buildings.Where(building => building.Units.Any(u => u.unitComponents.Any(uC => uC.NumberComponent == num && uC.component.Name =="Bed"))).ToList();
            return _context.buildings.Where(building => building.Units.Any(u => u.NumberOfBedrooms == num && u.status== Status.active)).ToList();

        }

        public List<Building> FilterBasedOnUnitStatus()
        {
            return _context.buildings.Where(building => building.Units.Any(u => u.status == Status.active)).ToList();
        }

        public List<Building> FilterByCompoundNumber(int num)
        {
            return _context.buildings.Where(building=> building.CompoundId == num).ToList();
        }

        public List<Building> FilterByStatus()
        {
            return _context.buildings.Where(building=>building.status == Status.active).ToList();
        }

    }
}
