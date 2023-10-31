using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposatories
{
    public interface IBuilding :ICrudOperation<Building>
    {
        public List<Building> FilterByCompoundNumber(int num);
        public List<Building> FilterByStatus();
        public List<Building> FilterBasedOnUnitStatus();
        public List<Building> FilterBasedOnUnitFloor(int num);
        public List<Building> FilterBasedOnUnitNumBedRooms(int num);






    }
}
