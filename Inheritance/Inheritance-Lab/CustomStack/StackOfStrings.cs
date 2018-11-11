using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings
    {
        private List<string> data;

        public StackOfStrings()
        {
            this.data = new List<string>();
        }

        public void Push(string element)
        {
            this.data.Add(element);
        }

        public string Pop()
        {
            string element = this.GetLastElement();
            this.data.RemoveAt(this.data.Count - 1);
            return element;
        }

        public string Peek()
        {
            return this.GetLastElement();
        }

        public bool IsEmpty()
        {
            return this.data.Count == 0;
        }

        private string GetLastElement()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return this.data[this.data.Count - 1];
        }
    }
}
