using CollectoinHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectoinHierarchy.Collections
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private LinkedList<string> elements;

        public AddRemoveCollection()
        {
            this.elements = new LinkedList<string>();
        }

        public int Add(string element)
        {
            this.elements.AddFirst(element);
            return 0;
        }

        public string Remove()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            string lastElement = elements.Last.Value;
            this.elements.RemoveLast();
            return lastElement;
        }
    }
}
