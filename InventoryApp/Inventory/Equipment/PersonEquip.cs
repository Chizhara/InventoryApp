using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Items.Wear;
using InventoryApp.Items;

namespace InventoryApp.Inventory.Equipment
{
    class PersonEquip : Equip
    {
        public GameItem Head { get; protected set; }
        public GameItem Body { get; protected set; }
        public GameItem Legs { get; protected set; }
        public GameItem Arms { get; protected set; }

        public PersonEquip(List<GameItem> itemsList)
            : base(itemsList) { }

        public override void EquipItem(int itemPosition)
        {
            if (itemsList[itemPosition] is IWear)
            {
                if (((IWear)itemsList[itemPosition]).WearType.HasFlag(WearTypeEnum.Head))
                    Head = itemsList[itemPosition];
                if (((IWear)itemsList[itemPosition]).WearType.HasFlag(WearTypeEnum.Body))
                    Body = itemsList[itemPosition];
                if (((IWear)itemsList[itemPosition]).WearType.HasFlag(WearTypeEnum.Legs))
                    Legs = itemsList[itemPosition];
                if (((IWear)itemsList[itemPosition]).WearType.HasFlag(WearTypeEnum.Arms))
                    Arms = itemsList[itemPosition];
                if (!((IWear)itemsList[itemPosition]).WearType.HasFlag(WearTypeEnum.Head | WearTypeEnum.Body | WearTypeEnum.Legs | WearTypeEnum.Arms))
                    throw new Exception("Отсутвует слот для такого типа брони");
            }
            else
                throw new Exception("Данный предмет не может быть надетым");
        }

        public override GameItem GetEquipedItem(WearTypeEnum slot)
        {
            switch (slot) 
                {
                case WearTypeEnum.Head:
                    return Head;
                case WearTypeEnum.Body:
                    return Body;
                case WearTypeEnum.Legs:
                    return Legs;
                case WearTypeEnum.Arms:
                    return Arms;
                default:
                    throw new AggregateException("Отсутвует слот для такого типа брони");
            }               
        }

        public override void RemoveItem(int itemPosition)
        {
            if (itemsList[itemPosition] == Head)
                Head = null;
            if (itemsList[itemPosition] == Body)
                Body = null;
            if (itemsList[itemPosition] == Legs)
                Legs = null;
            if (itemsList[itemPosition] == Arms)
                Arms = null;
        }

        public override int GetDefenseRate()
        {
            int defensePonts = 0;

            if (Head is Armor) defensePonts += ((Armor)Head).DefensePoints;
            if (Body is Armor) defensePonts += ((Armor)Body).DefensePoints;
            if (Legs is Armor) defensePonts += ((Armor)Legs).DefensePoints;
            if (Arms is Armor) defensePonts += ((Armor)Arms).DefensePoints;

            return defensePonts;
        }

        public override int GetAdditionalWeight()
        {
            int addiitionalWeight = 0;

            if (Head is CaseWear) addiitionalWeight += ((CaseWear)Head).AdditionalWeight;
            if (Body is CaseWear) addiitionalWeight += ((CaseWear)Body).AdditionalWeight;
            if (Legs is CaseWear) addiitionalWeight += ((CaseWear)Legs).AdditionalWeight;
            if (Arms is CaseWear) addiitionalWeight += ((CaseWear)Arms).AdditionalWeight;

            return addiitionalWeight;
        }
    }
}
