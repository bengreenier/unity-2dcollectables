using System;
using UnityEngine;
using UnityEngine.Events;

namespace TwoDCollectables.Utilities
{
    /// <summary>
    /// Randomizes floats within a given range at a given interval
    /// </summary>
    /// <remarks>
    /// The interval may be driven by the randomized value itself
    /// </remarks>
    public class RangeRandomizer : MonoBehaviour
    {
        [Serializable]
        public class RangeChangedEvent : UnityEvent<float>
        {
        }

        [Tooltip("The interval in seconds the range will change. -1 treats the range value as a time, and changes accordingly")]
        public float Interval = -1;

        [Tooltip("The minimum interval value in seconds")]
        public float MinValue = 0f;

        [Tooltip("The maximum interval value in seconds")]
        public float MaxValue = 10f;

        [Tooltip("The action to take when the value changes")]
        public RangeChangedEvent OnChanged;
        
        private float timeSinceLastChange = 0f;

        private float lastValue = 0f;
        
        private void Update()
        {
            var tickMax = Interval == -1 ? lastValue : Interval;

            if (timeSinceLastChange >= tickMax)
            {
                lastValue = UnityEngine.Random.Range(MinValue, MaxValue);
                timeSinceLastChange = 0f;

                OnChanged.Invoke(lastValue);
            }
            else
            {
                timeSinceLastChange += Time.deltaTime;
            }
        }
    }
}
