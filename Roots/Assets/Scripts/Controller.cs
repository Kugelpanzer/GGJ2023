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
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + scoreCounter.ToString();
    }

    public void DealDamageToPlayer(int damage)
    {
        currentPlayerHealth -= damage;
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
