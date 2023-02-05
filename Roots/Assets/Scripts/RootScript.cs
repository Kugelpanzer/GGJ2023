using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootScript : MonoBehaviour
{
    public GameObject ork;
    public void EndAnimation()
    {
        if(ork == null)
            Destroy(gameObject);
    }
}
