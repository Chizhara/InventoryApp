using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Items
{
    public class GameItem
    {
        public string Name { get; set; }
        public int Weight { get; protected set; }

        public GameItem(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
