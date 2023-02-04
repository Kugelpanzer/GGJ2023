using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;

    public static bool isPaused = false;

    public List<BaseEnemy> allEnemies = new List<BaseEnemy>();
    public Transform playerTarget;


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

    }



    // Update is called once per frame
    void Update()
    {
    }
}
