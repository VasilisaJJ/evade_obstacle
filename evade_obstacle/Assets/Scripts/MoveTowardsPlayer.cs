using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public float speed = 1f;

    private Transform playerTransform;
    private bool isMoving = false;

    private void Start()
    {
        playerTransform = null;
    }

    private void Update()
    {
        if (isMoving && playerTransform != null)
        {
            MoveToPlayer();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isMoving = true;
            playerTransform = col.gameObject.transform;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isMoving = false;
            playerTransform = null;
        }
    }

    private void MoveToPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime));
    }
}
