using UnityEngine;

namespace TwoDCollectables
{
    /// <summary>
    /// Storage class for constants related to <see cref="ICollector"/>
    /// </summary>
    internal static class ICollectorConstants
    {
        /// <summary>
        /// Represents the method name of <see cref="ICollector.OnCollected(Collectable)"/>
        /// </summary>
        /// <remarks>
        /// This is necessary to use <see cref="UnityEngine.GameObject.SendMessage(string, object, SendMessageOptions)"/>
        /// from <see cref="Collectable.OnTriggerEnter(Collider)"/>
        /// </remarks>
        public static readonly string OnCollectedMethodName = "OnCollected";
    }

    /// <summary>
    /// Represents a script capable of collecting <see cref="Collectable"/>s
    /// </summary>
    public interface ICollector
    {
        /// <summary>
        /// Called when a <see cref="Collectable"/> is collected
        /// </summary>
        /// <param name="item">the item that was collected</param>
        void OnCollected(Collectable item);
    }
}
