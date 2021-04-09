using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    float xInput;
    float zInput;
    bool boost;

    private float moveSpeed = 4;

    public CharacterController controller;

    //public float speed = 12f;

    float timeStamp = 0;

    int boostCounter = 0;

    public Transform pad, holder;

    Vector3 boostVelocity;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        boost = false;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: change from H/V to keydown inputs?
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        //boost = Input.GetKeyDown(KeyCode.Space);

        

        if(boost && boostCounter > 5)
        {
            boost = false;
            boostCounter = 0;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            boost = true;
            boostVelocity = new Vector3(rb.velocity.x * 2.5f, rb.velocity.y, rb.velocity.z * 2.5f);
        }



        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");


        //Vector3 move = transform.up * -x + transform.right * -z;

        //controller.Move(move * speed * Time.deltaTime);
        //pad.localPosition = 
        //transform.localPosition = transform.localPosition;

    }

    private void FixedUpdate()
    {
        float xVelocity = xInput * moveSpeed;
        float zVelocity = zInput * moveSpeed;

        if (boost)
        {
            //rb.velocity = new Vector3(-6, rb.velocity.y, rb.velocity.z);
            rb.velocity = boostVelocity;
            boostCounter++;
        }
        else
        {
            rb.velocity = new Vector3(-zVelocity, rb.velocity.y, xVelocity);
        }
        
    }
}
