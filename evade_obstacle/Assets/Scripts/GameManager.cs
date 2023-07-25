using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerTrail;
    public Transform startPoint;
    public Spawner spawner;
    public TMP_Text scoreText;
    public GameObject startText;

    private int currentScore = 0;
    private static GameManager instance;
    private bool canStartGame = true;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("GameManagerSingleton");
                    instance = singleton.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    
    void Start()
    {
        EndGame();
    }
    
    void Update()
    {
        if (!canStartGame) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canStartGame = false;
            StartGame();
        }
    }

    public void EndGame()
    {
        currentScore = 0;
        player.transform.position = startPoint.transform.position;
        spawner.EndSpawn();
        playerTrail.SetActive(false);
        player.GetComponent<PlayerBehavior>().EndGame();
        canStartGame = true;
        startText.SetActive(true);
        scoreText.text = "Score: " + currentScore;
    }

    public void Score()
    {
        currentScore++;
        scoreText.text = "Score: " + currentScore;
    }

    public void StartGame()
    {
        spawner.StartSpawn();
        player.GetComponent<PlayerBehavior>().StartGame();
        startText.SetActive(false);
        playerTrail.SetActive(true);
    }
}
