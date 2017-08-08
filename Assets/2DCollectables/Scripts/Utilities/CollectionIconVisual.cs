using TwoDCollectables.Collectors;
using UnityEngine;

namespace TwoDCollectables.Utilities
{
    /// <summary>
    /// Creates a minature version of the sprite of the top element in a <see cref="BaseCollectionCollector"/>
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class CollectionIconVisual : MonoBehaviour
    {
        /// <summary>
        /// The collector to visualize the top of
        /// </summary>
        public BaseCollectionCollector Collector;
        
        private SpriteRenderer spriteRenderer;

        private Collectable lastPeek = null;
        
        private void Start()
        {
            this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            var peekCol = this.Collector.Peek();

            if (peekCol != lastPeek)
            {
                lastPeek = peekCol;

                var peekSprite = peekCol.GetComponent<SpriteRenderer>();

                if (peekSprite != null && peekSprite.sprite != null)
                {
                    this.spriteRenderer.sprite = peekSprite.sprite;
                }
            }
            else if (peekCol == null && this.spriteRenderer.sprite != null)
            {
                this.spriteRenderer.sprite = null;
            }
        }
    }
}
