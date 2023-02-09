using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseBuff : MonoBehaviour, IPointerClickHandler
{
    public float duration=2f;


    public bool rootAllEnemies = false;
    public bool heal = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (duration > 0)
        {
            duration -= Time.fixedDeltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (rootAllEnemies)
        {
            foreach( BaseEnemy gj in Controller.instance.allEnemies)
            {
                if(!gj.rooted)
                    gj.GetRooted();
            }
        } 
        
        if(heal)
        {
            Controller.instance.currentPlayerHealth++;
            if(Controller.instance.currentPlayerHealth> Controller.instance.playerHealth)
                Controller.instance.currentPlayerHealth = Controller.instance.playerHealth;
        }
        Controller.instance.SetScore(1);
        Destroy(gameObject);
    }
}
