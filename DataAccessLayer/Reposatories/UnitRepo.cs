using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussienesLayer.Reposatories
{
    public class UnitRepo : CrudOperation<Unit>,IUnit
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

        public List<Unit> FilterByNumOfFloor(int num)
        {
            return context.units.Where(u => u.status == Status.active &&
            u.Floor==num).ToList();
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
    }
}
