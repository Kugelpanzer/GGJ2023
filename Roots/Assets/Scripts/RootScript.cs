using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootScript : MonoBehaviour
{
    public GameObject ork;
    public bool orkDead = false;
    public void EndAnimation()
    {
        if (orkDead)
        {
            Destroy(ork);
            Destroy(gameObject);
        }
    }
}
