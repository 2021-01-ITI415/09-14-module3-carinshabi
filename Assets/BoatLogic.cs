using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatLogic : MonoBehaviour
{
    public GameObject pointA, pointB;
    public bool moveToPointA, moveToPointB;
    public bool canRideBoat = true, moveBoat = false;
    public float moveSpeed, rotateSpeed;
    public GameObject player;
    public CharacterController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")//Checks if the player has collided with the boat trigger
        {
            if (canRideBoat == true)//checks if the player can ride the boat
            {
                player = other.gameObject;// gets the player object

                playerController = player.GetComponent<CharacterController>();//get the player object's characterController

                playerController.enabled = false;//turn the player's characterController off so that we can move the player

                player.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);//Place the player inside of the boat

                player.transform.SetParent(transform);//Make the player a child of the boat, so that when the boat moves the player will move with it

                //Select which point to go to
                if (moveToPointB == true)//if the boat is at point b go to point a
                {
                    moveToPointA = true;
                    moveToPointB = false;
                }
                else if (moveToPointA == true)//if the boat is at point a go to point b
                {
                    moveToPointB = true;
                    moveToPointA = false;
                }
                else//if the boat is at either points go to point b
                {
                    moveToPointB = true;
                }


                moveBoat = true;//the boat is now able to move to the points
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canRideBoat = true;//if the player has left the boat turn canrideboat back to true, now the player can ride the boat again
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveBoat == true)
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


    }

    public void MoveToPoint(GameObject point)
    {
        if (Vector3.Distance(transform.position, point.transform.position) > 5)//Keep moving to the point till the player is 5 spaces away
        {

            Quaternion rotateTarget = Quaternion.LookRotation(point.transform.position - transform.position);//Where to rotate
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTarget, rotateSpeed * Time.deltaTime);//Rotate towards point

            transform.position = Vector3.MoveTowards(transform.position, point.transform.position, moveSpeed * Time.deltaTime);//Move towards point

        }
        else
        {
            player.transform.SetParent(null);//the player is no longer a child of the boat
            playerController.enabled = true;//turn the characterController back on so that the player can move again
            canRideBoat = false;//The player has to get off the boat so that they can ride again
            moveBoat = false;//Stops the boat from moving
        }
    }
}