using System;
using TwoDCollectables.Collectors;
using UnityEngine;

namespace TwoDCollectables
{
    /// <summary>
    /// Represents a collectable
    /// </summary>
    /// <remarks>
    /// You should add a <see cref="Collider"/> or a <see cref="Collider2D"/>
    /// </remarks>
    public class Collectable : MonoBehaviour
    {
        /// <summary>
        /// The dimensions in which collectable things can occur
        /// </summary>
        [Flags]
        public enum Dimensions
        {
            Two = 1,
            Three = 2
        }

        public struct CollectionEventData
        {
            public Collectable collectable;
            public Dimensions dimension;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.SendMessage(ICollectorConstants.OnCollectedMethodName,
                new CollectionEventData()
                {
                    collectable = this,
                    dimension = Dimensions.Two
                },
                SendMessageOptions.DontRequireReceiver);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.SendMessage(ICollectorConstants.OnCollectedMethodName,
                new CollectionEventData()
                {
                    collectable = this,
                    dimension = Dimensions.Two
                },
                SendMessageOptions.DontRequireReceiver);
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.SendMessage(ICollectorConstants.OnCollectedMethodName,
                new CollectionEventData()
                {
                    collectable = this,
                    dimension = Dimensions.Three
                },
                SendMessageOptions.DontRequireReceiver);
        }

        private void OnCollisionEnter(Collision other)
        {
            other.gameObject.SendMessage(ICollectorConstants.OnCollectedMethodName,
                new CollectionEventData()
                {
                    collectable = this,
                    dimension = Dimensions.Three
                },
                SendMessageOptions.DontRequireReceiver);
        }
    }
}
