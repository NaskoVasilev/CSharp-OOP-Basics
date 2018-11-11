using System;
using System.Collections.Generic;
using System.Text;

namespace CollectoinHierarchy.Contracts
{
    public interface IAddRemoveCollection : IAddCollection
    {
        /// <summary>
        /// Remove element from the collection
        /// </summary>
        /// <returns>Returns the removed element</returns>
        string Remove();
    }
}
