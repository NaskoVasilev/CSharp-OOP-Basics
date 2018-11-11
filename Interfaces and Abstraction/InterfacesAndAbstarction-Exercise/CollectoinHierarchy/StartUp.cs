using CollectoinHierarchy.Collections;
using CollectoinHierarchy.Contracts;
using System;
using System.Collections.Generic;

namespace CollectoinHierarchy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();
            int elementsCount = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            AddElements(addCollection, elements);
            AddElements(addRemoveCollection, elements);
            AddElements(myList, elements);

            RemoveElements(elementsCount, addRemoveCollection);
            RemoveElements(elementsCount, myList);
        }

        private static void RemoveElements(int elementsCount, IAddRemoveCollection collection)
        {
            List<string> removedElements = new List<string>();

            for (int i = 0; i < elementsCount; i++)
            {
                string removedElement = collection.Remove();
                removedElements.Add(removedElement);
            }

            Console.WriteLine(string.Join(' ', removedElements));
        }

        private static void AddElements(IAddCollection collection, string[] elements)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < elements.Length; i++)
            {
                int index = collection.Add(elements[i]);
                result.Add(index);
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
