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

    public int damageToPlayer = 1;
    public bool rooted = false;
    public float rootDuration = 0f;
    public Transform target;
    public GameObject fakeBody;
    private float animatorSpeed = 0;

    public GameObject currRoot ;
    public GameObject specialRoot;

    public float rootOffsetX =0;
    public float rootOffsetY = 0;
    public virtual void DealDamage(int damage)
    {
        health -= damage;
        if (health < damage)
        {
            Die();
        }
    }
    public virtual void GetRooted()
    {
        rooted = true;
        rootDuration = RootConfig.instance.rootDuration;
        if (specialRoot == null)
        {
            currRoot = Instantiate(Controller.instance.rootPrefab);
        }
        else
        {
            currRoot = Instantiate(specialRoot);
        }
        
        currRoot.transform.position = transform.position+new Vector3(rootOffsetX,rootOffsetY);
        currRoot.GetComponent<RootScript>().ork = gameObject;
        DealDamage(RootConfig.instance.rootDamage);
        AudioManager.instance.PlaySound("err2");
        if (fakeBody != null)
            fakeBody.GetComponent<Animator>().speed = 0;
    }
    public virtual void Die()
    {
        if (currRoot != null)
        {
            currRoot.GetComponent<RootScript>().orkDead = true;
        }
        rooted = true;
        //Destroy(gameObject);
        Controller.instance.SetScore( score);
        

    }

    //is triggered when enemy reaches the player
    public virtual void DieWithHonor()
    {
        Destroy(gameObject);
    }
    //this function is triggerd when enemy collides with player
    public virtual void AttackPlayer()
    {
        Controller.instance.DealDamageToPlayer(damageToPlayer);
        DieWithHonor();
    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        if (fakeBody != null)
            animatorSpeed = fakeBody.GetComponent<Animator>().speed;
        Controller.instance.allEnemies.Add(this);
        target = Controller.instance.playerTarget;

    }
    private void OnDestroy()
    {
        if(Controller.instance!=null)
            Controller.instance.allEnemies.Remove(this);
    }
    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if (!Controller.instance.isPaused)
        {
            if (!rooted)
            {
                Movement();
            }
            if (rootDuration > 0)
            {
                rootDuration -= Time.fixedDeltaTime;
            }
            else
            {
                if (fakeBody != null)
                    fakeBody.GetComponent<Animator>().speed= animatorSpeed ;
                rooted = false;
                Destroy(currRoot);
            }
        }
        
    }

    public virtual void Movement ()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!rooted)
            GetRooted();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerScript>() != null)
        {
            AttackPlayer();

        }
    }
}
