using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Inventory;
using InventoryApp.Items;
using InventoryApp.Inventory.Equipment;

namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryWeight concreteInventory = new InventoryWeight(200, EquipTypeEnum.PersonEquip);

            concreteInventory.TryAddItem(new GameItem("Зелька",5));

            Console.WriteLine(concreteInventory.Equipment.GetDefenseRate());

            Console.ReadKey();
        }
    }
}
