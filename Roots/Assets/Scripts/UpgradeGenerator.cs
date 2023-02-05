using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeGenerator : MonoBehaviour
{
    public float spawnTime = 3f;
    private float spawnTimeLeft;
    public float distanceToPlayer = 3f;
    public List<GameObject> upgradePrefabs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        spawnTimeLeft = spawnTime * Random.Range(0.8f, 1.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnTimeLeft -= Time.fixedDeltaTime;
        if (spawnTimeLeft < 0)
        {
            SpawnUpgrade();
            spawnTimeLeft = spawnTime * Random.Range(0.8f, 1.2f);
        }
    }

    public void SpawnUpgrade()
    {
        Vector2 topRigth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        float xx = Random.Range(bottomLeft.x, topRigth.x);
        float yy = Random.Range(bottomLeft.y, topRigth.y);

        if(Vector2.Distance(new Vector2(xx,yy),Controller.instance.playerTarget.position)> distanceToPlayer)
        {
            GameObject gj = Instantiate(upgradePrefabs[ Random.Range(0, upgradePrefabs.Count)]);
            gj.transform.position = new Vector2(xx, yy);
        }
    }
}
