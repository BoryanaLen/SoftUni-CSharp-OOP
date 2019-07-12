using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Add(item);

            return this.collection.Count - 1;
        }
    }
}
