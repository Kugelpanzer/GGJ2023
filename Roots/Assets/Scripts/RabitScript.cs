using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class RabitScript : MonoBehaviour, IPointerClickHandler
{

   
    public float speed;
    public Vector3 direction;
    public GameObject upgradeRootPrefab;
    public GameObject upgradeHealthPrefab;
    public List<GameObject> healList = new List<GameObject>();
    public List<GameObject> rootList = new List<GameObject>();

    public float sound = 0.5f;
    public float currSound = 0.5f;
    public bool isGolden = false;
    public int goldenPoints = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("direction "+ direction.x);
        if(direction.x>0)
            transform.localScale = new Vector2( -transform.localScale.x,transform.localScale.y);
        upgradeHealthPrefab = Controller.instance.healBuffPrefab;
        upgradeRootPrefab = Controller.instance.rootBuffPrefab;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currSound > 0)
        {
            currSound -= Time.fixedDeltaTime;

        }
        else
        {
            AudioManager.instance.PlaySound("zec");
            currSound = sound;
        }
        if (!Controller.instance.isPaused)
        {
            transform.position = Vector3.MoveTowards(transform.position,transform.position+ direction, speed * Time.fixedDeltaTime);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isGolden)
        {
            GameObject _heal = Instantiate(upgradeHealthPrefab);
            GameObject _root = Instantiate(upgradeRootPrefab);

            int pos1h = Random.Range(0, healList.Count);
            int pos1r = Random.Range(0, rootList.Count);

            int pos2h = Random.Range(0, healList.Count);
            int pos2r = Random.Range(0, rootList.Count);
            int i = 0;
            /* while(pos2r == pos1r)
             {
                 pos2r = Random.Range(0, rootList.Count);
                 i++;
                 if (i > 1000) break;
             }
             while(pos2h == pos1h)
             {
                 pos2h= Random.Range(0, healList.Count);

                 i++;
                 if (i > 1000) break;
             }*/

            _heal.transform.position = healList[pos1h].transform.position;
            _root.transform.position = rootList[pos1r].transform.position;

            /* _heal = Instantiate(upgradeHealthPrefab);
             _root = Instantiate(upgradeRootPrefab);

             _heal.transform.position = healList[pos2h].transform.position;
             _root.transform.position = rootList[pos2r].transform.position;*/
        }
        else
        {
            Controller.instance.SetScore(goldenPoints) ;
        }

    }
}
