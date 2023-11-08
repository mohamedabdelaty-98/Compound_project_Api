using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IBuilding :IGenericReposatory<Building>
    {
        public List<Building> FilterByCompoundNumber(int num);
        public List<Building> FilterByStatus();
        public List<Building> FilterBasedOnUnitStatus(int num);
        public List<Building> FilterBasedOnUnitFloor(int num,int compoundid);
        public List<Building> FilterBasedOnUnitNumBedRooms(int num,int compoundid);
        public List<Building> FilterBasedOnUnitareaGreaterthan(int num,int compoundid);
        public List<Building> FilterBasedOnUnitareaLessthan(int num,int compoundid);
        public List<Building> FilterBasedOnBuildingNumber(int buildingnumber,int compoundnumber);
        List<int> getBuildings(int compoundnunm);






    }
}
