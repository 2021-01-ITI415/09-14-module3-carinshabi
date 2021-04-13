using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{
    public CharacterController fpsCon;
    public Camera cam;
    public float spMod = 5;
    public float spModRot = 2;
    public GameObject placeHolder;
    float rotY = 0;
    float rotX = 0;
    float rotXY = 0;
    float ROT;
    float down;
    // Start is called before the first frame update
    void Start()
    {
        ROT = this.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    { 
        Look();
        WASD();
    }

    void Look()
    {
        rotY += Input.GetAxis("Mouse X") * spModRot;
        rotX += Input.GetAxis("Mouse Y") * spModRot;
        rotXY = Mathf.Clamp(rotX,-ROT, ROT);
        this.transform.localEulerAngles = new Vector3(-rotX, rotY, 0);
    }

    void WASD()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            fpsCon.Move(transform.forward * vert * spMod * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            fpsCon.Move(transform.forward * vert * spMod * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            fpsCon.Move(transform.right * horz * spMod * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            fpsCon.Move(transform.right * horz * spMod * Time.deltaTime);
        }
    }
}
