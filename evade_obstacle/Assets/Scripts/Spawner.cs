using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject collectable;
    public float spawnTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int stepsToLevel = 3;

    private float timer;
    private bool canSpawn = true;
    private int currentStep = 0;
    private int level = 1;

    private void Start()
    {
        StartSpawn();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime && canSpawn)
        {
            currentStep++;
            SpawnCollectable();

            if (currentStep > stepsToLevel)
            {
                level++;
                currentStep = 0;
            }

            for (int i = 0; i <= level; i++)
            {
                SpawnObstacle();
            }

            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(obstacle, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }

    void SpawnCollectable()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(collectable, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }

    public void EndSpawn()
    {
        canSpawn = false;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Spawned");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
    }

    public void StartSpawn()
    {
        timer = spawnTime;
        canSpawn = true;
        currentStep = 0;
        level = 1;
    }
}