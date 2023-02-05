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
        GameObject _heal = Instantiate(upgradeHealthPrefab);
        GameObject _root = Instantiate(upgradeRootPrefab);

        GameObject hPos = healList[Random.Range(0, healList.Count)];
        GameObject hRoot = rootList[Random.Range(0, rootList.Count)];


    }
}
