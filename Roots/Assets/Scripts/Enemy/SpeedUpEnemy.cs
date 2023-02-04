using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEnemy : BaseEnemy
{
    public float speedChange;
    public float Interval;
    public float randomTimeDelta = 0.2f;
    private float currentSpeed;
    private bool shouldIncrease = true;
    private float timeLapsed;
    

    public override void Start()
    {
        base.Start();
        currentSpeed = speed;
    }

    public override void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, currentSpeed * Time.fixedDeltaTime);

        timeLapsed = timeLapsed + Time.fixedDeltaTime;

        if (timeLapsed > Interval) {
            if  (shouldIncrease) { 
                currentSpeed = currentSpeed + speedChange;
                shouldIncrease = false;
                timeLapsed = Random.Range(-randomTimeDelta, randomTimeDelta)*Interval;
            }
            else {
                currentSpeed = currentSpeed - speedChange;
                shouldIncrease = true;
                timeLapsed = Random.Range(-randomTimeDelta, randomTimeDelta)*Interval;
            }
        }
    }

}



