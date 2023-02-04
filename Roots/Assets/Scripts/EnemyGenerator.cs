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
                    SpawnEnemy(enemyType.enemyPrefab);
                }
            }
        }
    }



    public void SpawnEnemy(GameObject enemyPrefab)
    {
        
        Vector2 topRigth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);

        Debug.DrawLine(new Vector3(0, 0, 0), topRigth, Color.red,20f);
        Debug.DrawLine(new Vector3(0, 0, 0), bottomLeft, Color.blue, 20f);

        int strana = Random.Range(0, 4); //0 - top, 1 - right, 2-bottom, 3-left
        if(strana == 0)
        {
            GameObject gj = Instantiate(enemyPrefab);
            Vector2 size = gj.GetComponent<SpriteRenderer>().size;
            float yy = topRigth.y + size.y;
            float xx = Random.Range(bottomLeft.x, topRigth.x);

            gj.transform.position = new Vector2(xx, yy);
        }
        else if(strana == 1)
        {
            GameObject gj = Instantiate(enemyPrefab);
            Vector2 size = gj.GetComponent<SpriteRenderer>().size;
            float yy = Random.Range(bottomLeft.y, topRigth.y);
            float xx = topRigth.x+size.x;
            gj.transform.position = new Vector2(xx, yy);
        }
        else if (strana == 2)
        {
            GameObject gj = Instantiate(enemyPrefab);
            Vector2 size = gj.GetComponent<SpriteRenderer>().size;
            float yy = bottomLeft.y - size.y;
            float xx = Random.Range(bottomLeft.x, topRigth.x);
            gj.transform.position = new Vector2(xx, yy);
        }
        else
        {
            GameObject gj = Instantiate(enemyPrefab);
            Vector2 size = gj.GetComponent<SpriteRenderer>().size;
            float yy = Random.Range(bottomLeft.y, topRigth.y);
            float xx = bottomLeft.x - size.x;
            gj.transform.position = new Vector2(xx, yy);
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
