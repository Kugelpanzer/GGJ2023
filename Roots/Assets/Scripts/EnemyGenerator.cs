using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator instance;
    public List<EnemyTypeGenerator> enemyTypes = new List<EnemyTypeGenerator> ();

    private void Awake () { if ( instance == null ) instance = this; }
    void OnDestroy () { instance = null; }

    // Start is called before the first frame update
    void Start ()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if ( !Controller.instance.isPaused )
        {
            // time flow
            // enemy generation 
        }
    }
}

[System.Serializable]
public class EnemyTypeGenerator
{
    public GameObject enemyPrefab;
    public float startsFrom;
    public float startSpawnTime;
    public float minSpawnTime;
    public float SpawnTimeDecrement;
    public float SpawnChance;
}
