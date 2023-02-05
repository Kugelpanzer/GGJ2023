using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public static Controller instance;


    public int playerHealth=10;
    public int currentPlayerHealth;
    public float scoreCounter;
    public TextMeshProUGUI ScoreText;

    public bool isPaused = false;
    public List<BaseEnemy> allEnemies = new List<BaseEnemy>();
    public Transform playerTarget;
    public GameObject rootPrefab;
    public GameObject healBuffPrefab;
    public GameObject rootBuffPrefab;

    public GameObject uiHealthLayout;
    public List<GameObject> uiHealth = new List<GameObject>();
    public GameObject uiImageHealth;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

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
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "SCORE " + scoreCounter.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelController.instance.QuitGame();
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
        LevelController.instance.ResetGame();
    }
}
