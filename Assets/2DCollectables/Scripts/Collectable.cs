using TwoDCollectables.Collectors;
using UnityEngine;

namespace TwoDCollectables
{
    /// <summary>
    /// Represents a collectable
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class Collectable : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.SendMessage(ICollectorConstants.OnCollectedMethodName, this, SendMessageOptions.DontRequireReceiver);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.SendMessage(ICollectorConstants.OnCollectedMethodName, this, SendMessageOptions.DontRequireReceiver);
        }
    }
}
