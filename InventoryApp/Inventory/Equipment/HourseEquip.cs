using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Items.Wear;
using InventoryApp.Items;


namespace InventoryApp.Inventory.Equipment
{
    class HourseEquip : Equip
    {
        public GameItem Seddle { get; protected set; }

        public HourseEquip(List<GameItem> itemsList)
            : base(itemsList) { }

        public override void EquipItem(int itemPosition)
        {       
            if (itemsList[itemPosition] is IWear)
            {
                if (!((IWear)itemsList[itemPosition]).WearType.HasFlag(WearTypeEnum.Saddle))
                    throw new AggregateException("Отсутвует слот для такого типа брони");
                if (((IWear)itemsList[itemPosition]).WearType.HasFlag(WearTypeEnum.Saddle))
                    Seddle = itemsList[itemPosition];
            }
        }

        public override GameItem GetEquipedItem(WearTypeEnum slot)
        {
            if (slot.HasFlag(WearTypeEnum.Head))
                return Seddle;
            else
                throw new AggregateException("Отсутвует слот для такого типа брони");
        }

        public override void RemoveItem(int itemPosition)
        {
            if ((itemsList[itemPosition] is IWear) && ((IWear)itemsList[itemPosition]).WearType.HasFlag(WearTypeEnum.Saddle))
                Seddle = null;
        }

        public override int GetDefenseRate()
        {
            int defensePonts = 0;

            if(Seddle is Armor)
                defensePonts += ((Armor)Seddle).DefensePoints;

            return defensePonts;
        }

        public override int GetAdditionalWeight()
        {
            int addiitionalWeight = 0;

            if (Seddle is CaseWear)
                addiitionalWeight += ((CaseWear)Seddle).AdditionalWeight;

            return addiitionalWeight;
        }
    }
}
