using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootConfig : MonoBehaviour
{
    public static RootConfig instance;

    public float startingRootDuration = 1f;
    public int startingRootDamage = 1;

    public float rootDuration;
    public int rootDamage;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void OnDestroy()
    {
        instance = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        rootDuration = startingRootDuration;
        rootDamage = startingRootDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
