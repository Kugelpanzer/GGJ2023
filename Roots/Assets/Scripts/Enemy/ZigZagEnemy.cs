using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemy : BaseEnemy
{
    public float ZigZagAngle;
    private bool ZigOrZag;

    public float ZigZagTime;
    private float ZigZagTimeLeft;

    public override void Start ()
    {
        ZigOrZag = Random.Range ( 0, 2 ) < 1;
        ZigZagTimeLeft = ZigZagTime;
        base.Start ();
    }

    public override void FixedUpdate ()
    {
        if ( !Controller.instance.isPaused )
        {
            if ( !rooted )
            {
                // zig zag switch
                ZigZagTimeLeft -= Time.fixedDeltaTime;
                if ( ZigZagTimeLeft < 0 )
                {
                    ZigOrZag = !ZigOrZag;
                    ZigZagTimeLeft = ZigZagTime;
                }

                // movement
                Vector3 direction = target.position - transform.position;
                direction = Quaternion.Euler ( 0, 0, ZigZagAngle * (ZigOrZag ? 1 : -1) ) * direction;
                transform.position = Vector3.MoveTowards ( transform.position, transform.position + direction, speed * Time.fixedDeltaTime );
            }
            if ( rootDuration > 0 )
            {
                rootDuration -= Time.fixedDeltaTime;
            }
            else
            {
                rooted = false;
            }
        }

    }
}
