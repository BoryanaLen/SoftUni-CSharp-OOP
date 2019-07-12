using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : IAddRemoveCollection
    {
        private List<string> collection;

        public int Used => this.collection.Count;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            string itemToRemove = null;

            if (this.collection.Count > 0)
            {
                itemToRemove = this.collection[0];

                this.collection.RemoveAt(0);
            }

            return itemToRemove;
        }
    }
}
