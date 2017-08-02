using System;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDCollectables.Collectors
{
    /// <summary>
    /// A collector that stores (and exposes) a stack of collected items
    /// </summary>
    class StackCollector : MonoBehaviour, ICollector
    {
        /// <summary>
        /// The max number of items allowed in the stack at a given time
        /// </summary>
        public int MaxItems = 5;
        
        /// <summary>
        /// Peeks the item at the top of the stack
        /// </summary>
        /// <returns>the top <see cref="Collectable"/> on the stack</returns>
        public Collectable Peek()
        {
            return items.Count > 0 ? items.Peek() : null;
        }

        /// <summary>
        /// Pops the item at the top of the stack
        /// </summary>
        /// <returns>the top <see cref="Collectable"/> on the stack</returns>
        public Collectable Pop()
        {
            return items.Count > 0 ? items.Pop() : null;
        }

        private Stack<Collectable> items = new Stack<Collectable>();

        private GameObject itemStack;

        private void Awake()
        {
            this.itemStack = new GameObject("__itemStack");
            this.itemStack.transform.SetParent(this.transform);
            this.itemStack.SetActive(false);
        }

        public void OnCollected(Collectable item)
        {
            if (this.items.Count < this.MaxItems)
            {
                this.items.Push(item);

                // note: we don't delete the object, we just move it to the item stack
                // and since that stack is not active it stops being active as well
                item.gameObject.transform.SetParent(itemStack.transform);
            }
        }
    }
}
