using System.Collections.Generic;
using UnityEngine;

namespace TwoDCollectables.Collectors
{
    /// <summary>
    /// Base class for collection collectors
    /// </summary>
    /// <remarks>
    /// This simplifies development of components that can work with any ICollectableCollection
    /// but must be wire-able in the inspector
    /// </remarks>
    public abstract class BaseCollectionCollector : MonoBehaviour, ICollector, ICollectableCollection
    {
        public abstract IEnumerable<Collectable> Items { get; }

        public abstract void OnCollected(Collectable item);

        public abstract Collectable Peek();

        public abstract Collectable Pop();
    }
}
