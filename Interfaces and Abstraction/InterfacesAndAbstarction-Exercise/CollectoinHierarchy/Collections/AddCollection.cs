using CollectoinHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectoinHierarchy.Collections
{
    public class AddCollection : IAddCollection
    {
        private List<string> elements;

        public AddCollection()
        {
            this.elements = new List<string>();
        }

        public int Add(string element)
        {
            this.elements.Add(element);
            return elements.Count - 1;
        }
    }
}
