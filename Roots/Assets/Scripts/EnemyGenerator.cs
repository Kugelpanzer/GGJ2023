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

[Serializable]
public class EnemyTypeGenerator
{
    public GameObject enemyPrefab;
    float startsFrom;
    float startSpawnTime;
    float minSpawnTime;
    float SpawnTimeDecrement;
    float SpawnChance;
}
