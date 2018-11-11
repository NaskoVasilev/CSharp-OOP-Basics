using System;
using System.Collections.Generic;
using System.Text;

namespace CollectoinHierarchy.Contracts
{
    public interface IAddCollection
    {
        /// <summary>
        /// Add element in the collection
        /// </summary>
        /// <param name="element"></param>
        /// <returns>The index in which the element was added</returns>
        int Add(string element);
    }
}
