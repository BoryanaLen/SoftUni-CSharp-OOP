using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm
{
    public abstract class Food : IFood
    {
        public int Quantity { get; private set; }

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
