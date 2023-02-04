using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class RabitScript : MonoBehaviour, IPointerClickHandler
{

   
    public float speed;
    public Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }
}
