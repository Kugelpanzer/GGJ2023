using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public static Controller instance;


    public int playerHealth=10;
    public int currentPlayerHealth;
    public int scoreCounter;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;

    public bool isPaused = false;
    public List<BaseEnemy> allEnemies = new List<BaseEnemy>();
    public Transform playerTarget;
    public GameObject rootPrefab;
    public GameObject healBuffPrefab;
    public GameObject rootBuffPrefab;

    public GameObject uiHealthLayout;
    public List<GameObject> uiHealth = new List<GameObject>();
    public GameObject uiImageHealth;

    public Texture2D cursorTexture;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
    }
    void OnDestroy()
    {
        instance = null;
    }
    // Start is called before the first frame update
    void Start()
    {

        currentPlayerHealth = playerHealth;
        for (int i = 0; i < currentPlayerHealth; i++)
        {
            uiHealth.Add(Instantiate(uiImageHealth, uiHealthLayout.transform));
        }
        SetScore(0);
    }
    public void SetScore(int score)
    {
        scoreCounter += score;
        PlayerPrefs.SetInt("score", scoreCounter);
        if (PlayerPrefs.GetInt("high_score") < scoreCounter)
        {
            PlayerPrefs.SetInt("high_score", scoreCounter);
        }

        highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("high_score").ToString();
        scoreText.text = "SCORE: " + scoreCounter.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelController.instance.ResetGame();
        }
    }

    public void DealDamageToPlayer(int damage)
    {
        currentPlayerHealth -= damage;
        if(currentPlayerHealth> 0)
        {
            foreach(GameObject g in uiHealth)
            {
                Destroy(g);
            }
            uiHealth.Clear();
            for(int i=0;i < currentPlayerHealth; i++)
            {
                uiHealth.Add(Instantiate(uiImageHealth, uiHealthLayout.transform));
            }
        }
        if (currentPlayerHealth <= 0)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        LevelController.instance.NextScene();
    }
}
