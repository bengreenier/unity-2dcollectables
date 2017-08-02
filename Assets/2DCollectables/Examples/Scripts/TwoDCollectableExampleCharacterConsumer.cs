using UnityEngine;
using TwoDCollectables.Collectors;

[RequireComponent(typeof(StackCollector))]
public class TwoDCollectableExampleCharacterConsumer : MonoBehaviour
{
    private StackCollector collector;

    private void Awake()
    {
        this.collector = this.GetComponent<StackCollector>();

        if (this.collector == null)
        {
            throw new System.Exception("the character must have a StackCollector");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.collector.Peek() != null)
            {
                var item = this.collector.Pop();
                Debug.Log("Consuming " + item.name);
                Destroy(item.gameObject);
            }
        }
    }
}
