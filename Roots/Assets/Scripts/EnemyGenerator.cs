using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public List<EnemyTypeGenerator> enemyTypes = new List<EnemyTypeGenerator> ();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
