using System;
using System.Collections.Generic;
using System.Text;

namespace CollectoinHierarchy.Contracts
{
    interface IMyList : IAddRemoveCollection
    {
        /// <summary>
        /// The count of elements in the collection
        /// </summary>
        int Used { get; }
    }
}
