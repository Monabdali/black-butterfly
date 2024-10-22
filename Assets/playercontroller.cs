using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{ public float speed = 6f;
    public float gravity = 20f;
    public float Jump =8f;

    CharacterController controller;

    Vector3 moveDirection = Vector3.zero;
    Animator anim;
    public float rotSpeed =80f;
    float rot = 0f;
    float horizontal;
    float vertical;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0.0f, vertical); // to move back and forward
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);
            if(Input.GetButton("Jump"))
            {
                moveDirection.y=Jump;
            }
            if(Input.GetKey(KeyCode.W))
            {
                anim.SetBool("IsWalking",true);
            }
            else 
            {
               anim.SetBool("IsWalking",false); 

            }
        }

        rot +=Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0,rot,0);

        moveDirection.y -= gravity * Time.deltaTime; // apply gravity
        controller.Move(moveDirection * Time.deltaTime);
    }
}
