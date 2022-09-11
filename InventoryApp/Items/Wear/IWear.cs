using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Items.Wear
{
    public interface IWear
    {
        WearTypeEnum WearType { get; }
    }

    [Flags]
    public enum WearTypeEnum
    {
        None = 0,
        Head = 1,
        Body = 2,
        Arms = 4,
        Legs = 8,
        Saddle = 16
    }
}
