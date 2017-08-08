using System;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDCollectables.Collectors
{
    /// <summary>
    /// A collector that stores (and exposes) a stack of collected items
    /// </summary>
    class StackCollector : BaseCollectionCollector
    {
        /// <summary>
        /// The max number of items allowed in the stack at a given time
        /// </summary>
        public int MaxItems = 5;

        /// <summary>
        /// Peeks the item at the top of the stack
        /// </summary>
        /// <returns>the top <see cref="Collectable"/> on the stack</returns>
        public override Collectable Peek()
        {
            return items.Count > 0 ? items.Peek() : null;
        }

        /// <summary>
        /// Pops the item at the top of the stack
        /// </summary>
        /// <returns>the top <see cref="Collectable"/> on the stack</returns>
        public override Collectable Pop()
        {
            return items.Count > 0 ? items.Pop() : null;
        }

        /// <summary>
        /// Enumerable collection of items in the stack
        /// </summary>
        public override IEnumerable<Collectable> Items
        {
            get
            {
                return items;
            }
        }

        private Stack<Collectable> items = new Stack<Collectable>();

        private GameObject itemStack;

        private void Awake()
        {
            this.itemStack = new GameObject("__itemStack");
            this.itemStack.transform.SetParent(this.transform);
            this.itemStack.SetActive(false);
        }

        public override void OnCollected(Collectable.CollectionEventData eventData)
        {
            if (this.items.Count < this.MaxItems)
            {
                this.items.Push(eventData.collectable);

                // note: we don't delete the object, we just move it to the item stack
                // and since that stack is not active it stops being active as well
                eventData.collectable.gameObject.transform.SetParent(itemStack.transform);
            }
        }
    }
}
