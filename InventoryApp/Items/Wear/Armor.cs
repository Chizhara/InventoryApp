using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Items.Wear
{
    class Armor : GameItem, IWear
    {
        public int DefensePoints { get; protected set; }

        public Armor(string name, int weight, int defensePoints, WearTypeEnum wearType)
            : base(name, weight) 
        {
            if (defensePoints < 0)
                throw new Exception("Очки брони не могут быть отрицательным значением");

            WearType = wearType;
            DefensePoints = defensePoints;
        }

        public WearTypeEnum WearType
        {
            get => WearType;
            protected set => WearType = value;
        }
    }   
}
