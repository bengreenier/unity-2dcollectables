using System;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDCollectables.Collectors
{
    /// <summary>
    /// A collector that stores (and exposes) a queue of collected items
    /// </summary>
    class QueueCollector : BaseCollectionCollector
    {
        /// <summary>
        /// The max number of items allowed in the queue at a given time
        /// </summary>
        public int MaxItems = 5;
        
        /// <summary>
        /// Peeks the item at the front of the queue
        /// </summary>
        /// <returns>the top <see cref="Collectable"/> on the queue</returns>
        public override Collectable Peek()
        {
            return items.Count > 0 ? items.Peek() : null;
        }

        /// <summary>
        /// Pops the item at the front of the queue
        /// </summary>
        /// <returns>the top <see cref="Collectable"/> on the queue</returns>
        public override Collectable Pop()
        {
            return items.Count > 0 ? items.Dequeue() : null;
        }

        /// <summary>
        /// Enumerable collection of items in the stack
        /// </summary>
        public override IEnumerable<Collectable> Items
        {
            get
            {
                return this.items;
            }
        }

        private Queue<Collectable> items = new Queue<Collectable>();

        private GameObject collectedItems;

        private void Awake()
        {
            this.collectedItems = new GameObject("__collected");
            this.collectedItems.transform.SetParent(this.transform);
            this.collectedItems.SetActive(false);
        }

        public override void OnCollected(Collectable.CollectionEventData eventData)
        {
            if (this.items.Count < this.MaxItems)
            {
                this.items.Enqueue(eventData.collectable);

                // note: we don't delete the object, we just move it to the list
                // and since that stack is not active it stops being active as well
                eventData.collectable.gameObject.transform.SetParent(collectedItems.transform);
            }
        }
    }
}
