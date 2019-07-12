using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class Engine
    {
        public void Run()
        {
            List<string> inputInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> addCollectionIndexes = new List<int>();
            List<int> addRemoveCollectionIndexes = new List<int>();
            List<int> myListIndexes = new List<int>();

            foreach (var item in inputInfo)
            {
                addCollectionIndexes.Add(addCollection.Add(item));
                addRemoveCollectionIndexes.Add(addRemoveCollection.Add(item));
                myListIndexes.Add(myList.Add(item));
            }

            Console.WriteLine(string.Join(' ', addCollectionIndexes));
            Console.WriteLine(string.Join(' ', addRemoveCollectionIndexes));
            Console.WriteLine(string.Join(' ', myListIndexes));

            int countRemoveOperations = int.Parse(Console.ReadLine());

            List<string> addRemoveCollectionRemoves = new List<string>();

            List<string> myListRemoves = new List<string>();

            for (int i = 0; i < countRemoveOperations; i++)
            {
                string addRemoveCollectionRemove = addRemoveCollection.Remove();

                string myListRemove = myList.Remove();

                if (addRemoveCollectionRemove != null)
                {
                    addRemoveCollectionRemoves.Add(addRemoveCollectionRemove);
                }

                if (myListRemove != null)
                {
                    myListRemoves.Add(myListRemove);
                }
            }

            Console.WriteLine(string.Join(' ', addRemoveCollectionRemoves));
            Console.WriteLine(string.Join(' ', myListRemoves));
        }
    }
}
