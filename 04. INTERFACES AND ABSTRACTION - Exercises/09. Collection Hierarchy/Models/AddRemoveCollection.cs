using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> collection;

        public AddRemoveCollection()
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
                itemToRemove = this.collection[collection.Count - 1];

                this.collection.RemoveAt(collection.Count - 1);
            }

            return itemToRemove;
        }
    }
}
