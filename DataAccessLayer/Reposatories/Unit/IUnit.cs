using DataAccessLayer.Models;

namespace DataAccessLayer.Reposatories
{
    public interface IUnit:IGenericReposatory<Unit>
    {
        List<Unit> FilterByStatus();
        List<Unit> FilterByNumOfFloor(int num);
        List<Unit> FilterByBuildingNumber(int num);
        List<Unit> FilterByNumberOfRoom(int num);
        List<Unit> FilterByAll(int FloorNum,int BuildingNum,int NumOfRoom);
    }
}
