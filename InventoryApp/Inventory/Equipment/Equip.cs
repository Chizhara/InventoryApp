using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Items.Wear;
using InventoryApp.Items;

namespace InventoryApp.Inventory.Equipment
{
    public abstract class Equip
    {
        protected List<GameItem> itemsList;

        public Equip(List<GameItem> itemsList)
        {
            this.itemsList = itemsList;
        }

        public abstract void EquipItem(int itemPosition);
        public abstract GameItem GetEquipedItem(WearTypeEnum slot);
        public abstract void RemoveItem(int itemPosition);
        public abstract int GetDefenseRate();
        public abstract int GetAdditionalWeight();

    }
}
