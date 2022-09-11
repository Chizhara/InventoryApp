using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Items;
using InventoryApp.Items.Wear;
using InventoryApp.Inventory.Equipment;

namespace InventoryApp.Inventory
{
    class InventoryWeight : Inventory
    {        
        private int inventoryCapacity;
        private int inventoryActualOccupancy;       

        public InventoryWeight(int capacity, EquipTypeEnum equipType)
        {
            if (capacity < 0)
                throw new Exception("Значение capacity не может быть отрицательным");

            inventoryCapacity = capacity;
            inventoryActualOccupancy = 0;
            itemsList = new List<GameItem>();

            switch (equipType)
            {
                case EquipTypeEnum.PersonEquip:
                    Equipment = new PersonEquip(itemsList);
                    break;
                case EquipTypeEnum.HourseEquip:
                    Equipment = new HourseEquip(itemsList);
                    break;
                default:
                    Equipment = null;
                    break;
            }
        }

        public override bool TryAddItem(GameItem item)
        {
            if (item.Weight + inventoryActualOccupancy <= inventoryCapacity)
            {
                inventoryActualOccupancy += (item).Weight;
                itemsList.Add(item);
                return true;
            }
            else 
                return false;
        }

        public override void AddItem(GameItem item)
        {
            if (item.Weight + inventoryActualOccupancy <= inventoryCapacity)
            {
                inventoryActualOccupancy += item.Weight;
                itemsList.Add(item);
            }
            else
                throw new Exception("Вес добовляемого предмета превышает допустимый");
        }

        public override string DropItemAtPosition(int itemPosition)
        {
            try
            {
                if (itemsList[itemPosition] is IWear)
                    Equipment.RemoveItem(itemPosition);

                inventoryActualOccupancy -= itemsList[itemPosition].Weight;
                string name = itemsList[itemPosition].Name;
                itemsList.RemoveAt(itemPosition);
                return name + " был выброшен на землю";
            }
            catch
            {
                return "Такой предмет отсутствует в инвентаре";
            }
        }       
    }

    
}
