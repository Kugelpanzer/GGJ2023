using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitGenerator : MonoBehaviour
{
    public static RabbitGenerator instance;
    public GameObject rabbitPrefab;
    private void Awake () { if ( instance == null ) instance = this; }
    void OnDestroy () { instance = null; }

    // Start is called before the first frame update
    void Start ()
    {
        SpawnRabbit(rabbitPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRabbit (GameObject rabbitPrefab)
    {
        GameObject rabbit = Instantiate ( rabbitPrefab );
        Vector2 size = rabbit.GetComponent<SpriteRenderer> ().size;

        Vector2 topRigth = Camera.main.ScreenToWorldPoint ( new Vector2 ( Screen.width, Screen.height ) );
        float minDimension = Mathf.Min ( topRigth.x, topRigth.y );
        Vector3 passPoint = ( Quaternion.Euler ( 0, 0, Random.Range ( 0f, 360f ) ) * Vector3.right ) * minDimension * Random.Range ( 0.3f, 0.9f );

        Plane topPlane = new Plane ( Vector3.down, topRigth.y + size.y );
        Plane bottomPlane = new Plane ( Vector3.up, topRigth.y + size.y );
        Plane rightPlane = new Plane ( Vector3.left, topRigth.x + size.x );
        Plane leftPlane = new Plane ( Vector3.right, topRigth.x + size.x );

        bool clockwise = Random.Range ( 0, 2 ) < 1;
        Vector3 rabbitDirection = ( Quaternion.Euler ( 0, 0, clockwise ? 90 : -90 ) * passPoint ).normalized;
        Ray rabbitMovement = new Ray ( passPoint, rabbitDirection );

        float distanceToTopPlane, distanceToBottomPlane, distanceToLeftPlane, distanceToRightPlane;
        float distanceBack = float.MinValue;

        if ( topPlane.Raycast ( rabbitMovement, out distanceToTopPlane ) )
        {
            if ( distanceToTopPlane < 0 && distanceToTopPlane > distanceBack )
                distanceBack = distanceToTopPlane;
        }
        if ( bottomPlane.Raycast ( rabbitMovement, out distanceToBottomPlane ) )
        {
            if ( distanceToBottomPlane < 0 && distanceToBottomPlane > distanceBack )
                distanceBack = distanceToBottomPlane;
        }
        if ( leftPlane.Raycast ( rabbitMovement, out distanceToLeftPlane ) )
        {
            if ( distanceToLeftPlane < 0 && distanceToLeftPlane > distanceBack )
                distanceBack = distanceToLeftPlane;
        }
        if ( rightPlane.Raycast ( rabbitMovement, out distanceToRightPlane ) )
        {
            if ( distanceToRightPlane < 0 && distanceToRightPlane > distanceBack )
                distanceBack = distanceToRightPlane;
        }

        Vector3 rabbitStartPoint = passPoint + rabbitDirection * distanceBack;
        Debug.Log(rabbitStartPoint);
        //rabbit.GetComponent<RabitScript>().transform.position = rabbitStartPoint;
        //rabbit.GetComponent<RabitScript>().direction = rabbitDirection;


    }
}
