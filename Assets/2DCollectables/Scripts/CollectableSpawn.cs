using TwoDCollectables.Collectors;
using UnityEngine;

namespace TwoDCollectables
{
    /// <summary>
    /// Represents a collectable spawner
    /// </summary>
    public class CollectableSpawn : MonoBehaviour
    {
        /// <summary>
        /// Should we spawn an item right away?
        /// </summary>
        public bool SpawnOnStart = false;

        /// <summary>
        /// The interval at which we spawn items
        /// </summary>
        public float Interval = 2f;

        /// <summary>
        /// Should we destroy and create new items if they haven't been consumed yet?
        /// </summary>
        public bool ReplaceExisting = false;

        /// <summary>
        /// Prevent spawning when a collector is within this range
        /// </summary>
        /// <remarks>
        /// 0, or negative numbers will disable this check
        /// </remarks>
        public float PreventSpawnCollectorRange = 0f;

        /// <summary>
        /// Resets the time until a new item spawns if <see cref="PreventSpawnCollectorRange"/>
        /// is in effect and a collector is within it's range
        /// </summary>
        public bool ResetIntervalOnPreventSpawn = true;

        /// <summary>
        /// The prefab list from which an item will be selected
        /// </summary>
        public GameObject[] ItemPrefabs;

        /// <summary>
        /// Internal time tracker
        /// </summary>
        private float timeSinceSpawn = 0f;

        /// <summary>
        /// Public setter of <see cref="Interval"/>
        /// </summary>
        /// <remarks>
        /// This can be wired to a unity event to control the interval dynamically
        /// </remarks>
        /// <param name="interval"></param>
        public void SetInterval(float interval)
        {
            this.Interval = interval;
        }

        /// <summary>
        /// Unity start hook
        /// </summary>
        private void Start()
        {
            if (this.SpawnOnStart)
            {
                SpawnItem();
            }
        }

        /// <summary>
        /// Unity update hook
        /// </summary>
        /// <remarks>
        /// This code assumes that the collectable spawner only ever contains at most one child that is collectable
        /// </remarks>
        private void Update()
        {
            if (this.timeSinceSpawn >= this.Interval)
            {
                if (transform.GetComponentInChildren<Collectable>() == null)
                {
                    bool allowSpawn = true;
                    if (this.PreventSpawnCollectorRange > 0f)
                    {
                        foreach (var overlap in Physics2D.OverlapCircleAll(transform.position, this.PreventSpawnCollectorRange))
                        {
                            if (overlap.GetComponent<ICollector>() != null)
                            {
                                allowSpawn = false;
                                break;
                            }
                        }
                    }

                    if (allowSpawn || this.ResetIntervalOnPreventSpawn)
                    {
                        this.timeSinceSpawn = 0f;
                    }

                    if (allowSpawn)
                    {
                        if (this.ReplaceExisting)
                        {
                            Destroy(transform.GetComponentInChildren<Collectable>().gameObject);
                        }

                        SpawnItem();
                    }
                }
            }
            else
            {
                this.timeSinceSpawn += Time.deltaTime;
            }
        }

        /// <summary>
        /// Item spawning helper
        /// </summary>
        private void SpawnItem()
        {
            Instantiate(this.SelectItem(this.ItemPrefabs), this.transform.position, this.transform.rotation, this.transform);
        }

        /// <summary>
        /// Item selector
        /// </summary>
        /// <remarks>
        /// Can be overriden in a child to change the behavior
        /// </remarks>
        /// <param name="itemList">the items to select from</param>
        /// <returns>the selected item</returns>
        protected virtual GameObject SelectItem(GameObject[] itemList)
        {
            return itemList[Random.Range(0, itemList.Length)];
        }
    }
}
