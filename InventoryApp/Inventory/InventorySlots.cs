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
    class InventorySlots : Inventory
    {
        public int MaxItems;

        public InventorySlots(int slotsCount, EquipTypeEnum equipType)
        {
            if (slotsCount < 0)
                throw new Exception("Значение slorsCount не может быть отрицательным");

            MaxItems = slotsCount;
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
            if (itemsList.Count() < MaxItems)
            {
                itemsList.Add(item);
                return true;
            }
            else
                return false;
        }

        public override void AddItem(GameItem item)
        {
            if (itemsList.Count() < MaxItems)
                itemsList.Add(item);
            else
                throw new Exception("В инвентаре не осталось свободного места");
        }

        public override string DropItemAtPosition(int itemPosition)
        {
            try
            {
                if (itemsList[itemPosition] is IWear)
                    Equipment.RemoveItem(itemPosition);

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
