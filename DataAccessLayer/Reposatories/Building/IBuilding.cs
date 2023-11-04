using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IBuilding :IGenericReposatory<Building>
    {
        public List<Building> FilterByCompoundNumber(int num);
        public List<Building> FilterByStatus();
        public List<Building> FilterBasedOnUnitStatus();
        public List<Building> FilterBasedOnUnitFloor(int num);
        public List<Building> FilterBasedOnUnitNumBedRooms(int num);






    }
}
