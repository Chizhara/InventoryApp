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
    abstract class Inventory
    {
        protected List<GameItem> itemsList;

        public Equip Equipment { get; protected set; }

        abstract public bool TryAddItem(GameItem item);
        abstract public void AddItem(GameItem item);
        abstract public string DropItemAtPosition(int itemPosition);

    }

    enum EquipTypeEnum
    {
        None,
        HourseEquip,
        PersonEquip
    }
}