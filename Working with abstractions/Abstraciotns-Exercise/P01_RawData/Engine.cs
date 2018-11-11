using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Engine
    {
        private int speed;
        private int power;

        public Engine(int power,int speed)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }


    }
}
