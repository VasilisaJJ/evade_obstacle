using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5f; 

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * (speed * Time.fixedDeltaTime));
    }
}
