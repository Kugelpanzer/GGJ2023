using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator instance;
    public List<EnemyTypeGenerator> enemyTypes = new List<EnemyTypeGenerator> ();
    private float elapsedTime = 0f;

    private void Awake () { if ( instance == null ) instance = this; }
    void OnDestroy () { instance = null; }

    // Start is called before the first frame update
    void Start ()
    {
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if ( !Controller.instance.isPaused )
        {
            // time flow
            elapsedTime += Time.fixedDeltaTime;

            // enemy generation
            foreach (EnemyTypeGenerator enemyType in enemyTypes)
            {
                if ( elapsedTime < enemyType.GetNextSpawnTime () ) continue;
                if ( enemyType.Spawn ( elapsedTime ) )
                {
                    // do actual spawn code
                }
            }
        }
    }
}

[System.Serializable]
public class EnemyTypeGenerator
{
    public GameObject enemyPrefab;
    public float startsFrom;
    public float startRespawnTime;
    public float minRespawnTime;
    public float RespawnTimeDecrement;
    public float SpawnChance;

    private float currentRespawnTime = float.MaxValue;
    private float nextSpawnTime = 0f;
    public float GetNextSpawnTime () => nextSpawnTime;

    public void Init ()
    {
        nextSpawnTime = startsFrom;
    }

    public bool Spawn ( float currentTime )
    {
        // calculate time interval to next spawn 
        if ( currentRespawnTime == float.MaxValue )
        {
            currentRespawnTime = startRespawnTime;
        }
        else
        {
            currentRespawnTime -= RespawnTimeDecrement;
            if ( currentRespawnTime < minRespawnTime ) currentRespawnTime = minRespawnTime;
        }

        // calculate next spawn time
        nextSpawnTime = currentTime + currentRespawnTime;

        // will it spawn?
        if ( SpawnChance >= 1f ) return true;
        if ( SpawnChance <= 0f ) return false;

        if ( Random.Range ( 0f, 1f ) <= SpawnChance ) return true;
        return false;
    }
}
