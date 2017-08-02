using System;
using UnityEngine;

namespace TwoDCollectables.Collectors
{
    /// <summary>
    /// Represents a basic collector, that collects <see cref="Collectable"/>s, logs their name, and removes them from the scene
    /// </summary>
    public class DefaultCollector : MonoBehaviour, ICollector
    {
        /// <summary>
        /// Handles collection by calling <see cref="Debug.Log(object)"/> with the collected items name, and then destroys the item
        /// </summary>
        /// <param name="item">the item that was collected</param>
        public void OnCollected(Collectable item)
        {
            Debug.Log("Collected " + item.name);
            Destroy(item.gameObject);
        }
    }
}
