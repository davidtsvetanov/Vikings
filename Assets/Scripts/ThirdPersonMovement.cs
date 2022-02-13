﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public GameObject Body;
    public CharacterController Controller;
    public Transform cam;
    public GameObject Player;
    public float speed = 6f;
    public float gravity = -5.81f;
    public float jumpheight = 2f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;
    Vector3 velocity;
    public Transform GroundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    bool isGrounded;
    public bool catOpen;
    public bool fpOpen;
    Animator Animator;
    public GameObject Weapon;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Animator = Body.GetComponent<Animator>();
     
    }


    // Update is called once per frame
    void Update()
    {
        if (Animator.GetCurrentAnimatorStateInfo(1).IsName("ReverseSwordHit"))
        {
        
            Animator.SetBool("InverseHit", false);
        }
            if (Animator.GetCurrentAnimatorStateInfo(1).IsName("NormalSwordHit"))
            {
            Animator.SetBool("SwordHit", false);
        }
            if (!Animator.GetCurrentAnimatorStateInfo(1).IsName("Default"))
        {
            var lookPos = cam.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(-lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100f);
        }
            velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime); 
       
      //  fpOpen = Player.GetComponent<MouseLookController>().fpOpen;

        //setting up sprint 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 35;

        }
        //cancel sprint
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8;
        }
        if (Input.GetMouseButtonDown(0))
        {
            switch (Weapon.tag)
            {
                case "Axe":
                    Animator.SetTrigger("Hit");
                    break;
                case "Sword":
                    if (Animator.GetCurrentAnimatorStateInfo(1).IsName("Default") || Animator.GetCurrentAnimatorStateInfo(1).IsName("ReverseSwordHit"))
                    {
                        Animator.SetBool("SwordHit", true);
                        Animator.SetBool("InverseHit", false);
                    }
                    else
                    {
                        Animator.SetBool("InverseHit", true);
                        Animator.SetBool("SwordHit", false); ;
                    }
                    break;
            }

         

            


        }
        if (!fpOpen && !catOpen)
        {
            
            isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y > 0)
            {
                velocity.y = -2f;
            }
           
            //setting up movment and movment animations
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                Animator.SetFloat("MovementSpeed", 2f);
            }
            else
            {
                Animator.SetFloat("MovementSpeed", 0f);
            }


            if (direction.magnitude >= 0.1f)
            {
                float target_angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_angle, ref turnSmoothVel, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, target_angle, 0f) * Vector3.forward;
                Controller.Move(moveDir * speed * Time.deltaTime);
                
            }
            //jumping
            if (Input.GetButton("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
                
            }
           
        }
    }
}
