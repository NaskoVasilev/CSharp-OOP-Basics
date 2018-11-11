using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food.Contracts;

namespace WildFarm.Food
{
    public abstract class Food : IFood
    {
        public double Quantity { get; set; }

        public Food(double quantity)
        {
            this.Quantity = quantity;
        }
    }
}
