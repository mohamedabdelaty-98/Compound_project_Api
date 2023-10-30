using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.Reposatories
{
    public interface IUnit:ICrudOperation<Unit>
    {
        List<Unit> FilterByStatus();
        List<Unit> FilterByNumOfFloor(int num);
        List<Unit> FilterByBuildingNumber(int num);
        List<Unit> FilterByNumberOfRoom(int num);
        List<Unit> FilterByAll(int FloorNum,int BuildingNum,int NumOfRoom);
    }
}
