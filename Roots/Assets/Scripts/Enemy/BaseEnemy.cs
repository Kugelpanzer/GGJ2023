using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseEnemy : MonoBehaviour, IPointerClickHandler
{
    public float speed = 1;
    public int health = 1;

    [Tooltip(" how much score do you get when you kill this enemy")]
    public int score = 1;
    public bool rooted = false;
    public float rootDuration = 0f;
    public Transform target;

    public virtual void Movement() 
    {
        
    }
    public virtual void GetRooted()
    {
        rooted = true;
        rootDuration = RootConfig.instance.rootDuration;
    }
    public virtual void Die()
    {

    }

    //this function is triggerd when enemy collides with player
    public virtual void AttackPlayer()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Controller.instance.allEnemies.Add(this);
        target = Controller.instance.playerTarget;
    }
    private void OnDestroy()
    {
        if(Controller.instance!=null)
            Controller.instance.allEnemies.Remove(this);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Controller.instance.isPaused)
        {
            if (!rooted)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed / 100);
            }
            if (rootDuration > 0)
            {
                rootDuration -= Time.deltaTime;
            }
            else
            {
                rooted = false;
            }
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetRooted();
        Debug.Log("Rooted ");
    }
}
