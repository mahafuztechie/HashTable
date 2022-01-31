using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class MyMapNode<K,V>
    {
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        /// Initializes a new instance of the <see cref="MyMapNode{K, V}"/> class.
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        /// <summary>
        /// Gets the array and linked list position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public LinkedList<KeyValue<K, V>> GetArrayAndLinkedListPosition(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            return linkedList;
        }
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public V Get(K key)
        {
            var linkedList = GetArrayAndLinkedListPosition(key);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
      
        public bool Exists(K key)
        {
            var linkedList = GetArrayAndLinkedListPosition(key);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Gets the linked list.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            foreach (var linkedlist in items)
            {
                if (linkedlist != null)
                {
                    foreach (var element in linkedlist)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + "  " + element.Value);
                    }
                }
            }
        }
    }
}
