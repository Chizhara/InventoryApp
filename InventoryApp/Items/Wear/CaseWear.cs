using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Items.Wear
{
    class CaseWear : GameItem, IWear
    {
        public int AdditionalWeight { get; protected set; }

        public CaseWear(string name, int weight, int additionalWeight, WearTypeEnum wearType)
            : base(name, weight)
        {
            if (additionalWeight < 0)
                throw new AggregateException("Дополнительный вес не может быть отрицательным");

            WearType = wearType;
            AdditionalWeight = additionalWeight;
        }

        public WearTypeEnum WearType
        {
            get => WearType;
            protected set => WearType = value;
        }
    }
}
