using CollectoinHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectoinHierarchy.Collections
{
    public class MyList : IMyList
    {
        private LinkedList<string> elements;
        public int Used { get; private set; }

        public MyList()
        {
            this.Used = 0;
            this.elements = new LinkedList<string>();
        }

        public int Add(string element)
        {
            this.elements.AddFirst(element);
            this.Used++;
            return 0;
        }

        public string Remove()
        {
            if (this.Used == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            string firstElement = this.elements.First.Value;
            this.elements.RemoveFirst();
            this.Used--;
            return firstElement;
        }
    }
}
