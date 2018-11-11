using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        private Random randomGenerator;

        public RandomList()
        {
            this.randomGenerator = new Random();
        }

        public string RandomString()
        {
            if (base.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
            int index = randomGenerator.Next(0, base.Count - 1);
            string element = base[index];
            base.RemoveAt(index);

            return element;
        }
    }
}
