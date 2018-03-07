using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWarhammerRoster
{
    public class Unit
    {

        public string unitName
        {
            get { return UnitName; }
        }

        public string unitType
        {
            get { return UnitType; }
        }

        public int unitCost
        {
            get { return UnitCost; }
        }
       


        private string UnitName;
        private string UnitType;
        private int UnitCost;

       
        public Unit(string name, string type, int cost)
        {
            UnitName = name;
            UnitType = type;
            UnitCost = cost;
        }
        
                   
       
    }
    
    }

    