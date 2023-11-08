using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IUnit:IGenericReposatory<Unit>
    {
        List<Unit> FilterByStatus();
        List<Unit> FilterByNumOfFloor(int num,int compoundid);
        List<int> getFloors(int compoundnunm);
        List<int> getBedroomNumber(int compoundnunm);
        
        List<Unit> FilterByBuildingNumber(int num);
        List<Unit> FilterByNumberOfRoom(int num);
        List<Unit> FilterByAll(int FloorNum,int BuildingNum,int NumOfRoom);
    }
}
