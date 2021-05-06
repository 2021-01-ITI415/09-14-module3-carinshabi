using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatLogic : MonoBehaviour
{
    public GameObject pointA, pointB;
    public bool moveToPointA, moveToPointB;
    public float moveSpeed, rotateSpeed;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            moveToPointB = true;
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveToPointA == true)
        {

            MoveToPoint(pointA);

        }

        if (moveToPointB == true)
        {

            MoveToPoint(pointB);

        }

    }

    public void MoveToPoint(GameObject point)
    {
        if (Vector3.Distance(transform.position, point.transform.position) > 10)
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            Quaternion rotateTarget = Quaternion.LookRotation(point.transform.position - transform.position);//Where to rotate
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTarget, rotateSpeed * Time.deltaTime);//Rotate towards point

            transform.position = Vector3.MoveTowards(transform.position, point.transform.position, moveSpeed * Time.deltaTime);//Move towards p

        }
    }
}
