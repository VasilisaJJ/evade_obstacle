using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float amplitudeMax = 2f; 
    public float amplitude; 
    public float frequencyMax = 2f; 
    public float frequency; 
    public bool moveUp = false; 

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        
        moveUp = Random.Range(0, 2) == 1;
        frequency = Random.Range(0, frequencyMax);
        amplitude = Random.Range(0, amplitudeMax);
    }

    private void Update()
    {
        float direction = moveUp ? 1f : -1f;
        float newYPosition = startPosition.y + direction * amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.EndGame();
        }
    }
}