using UnityEngine;

public class TwoDCollectableExampleCharacterController : MonoBehaviour
{
    public float MovementSpeed = 5f;

    private void Update()
    {
        Vector3 motionVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            motionVector += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            motionVector += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            motionVector += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            motionVector += Vector3.right;
        }

        this.transform.position += motionVector.normalized * this.MovementSpeed * Time.deltaTime;
    }
}
