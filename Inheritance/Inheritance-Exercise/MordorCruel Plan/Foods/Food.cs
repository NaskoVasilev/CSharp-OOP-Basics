using System;
using System.Collections.Generic;
using System.Text;

namespace MordorCruelPlan.Foods
{
    public abstract class Food
    {
        public int Happiness { get; }

        public Food(int happiness)
        {
            this.Happiness = happiness;
        }
    }
}
