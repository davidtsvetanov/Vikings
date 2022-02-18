using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    private float X;
    private float Y;
    public float speed = 6f;
    public Transform cam;
    public Transform ThirdPersonPlayer;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;
    public float Sensitivity;

    void Awake()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        X = euler.x;
        Y = euler.y;

        
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //if (direction.magnitude >= 0.1f)
        //{
        //    float target_angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + ThirdPersonPlayer.eulerAngles.y;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_angle, ref turnSmoothVel, turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //    Vector3 moveDir = Quaternion.Euler(0f, target_angle, 0f) * Vector3.forward;
        //    //Controller.Move(moveDir * speed * Time.deltaTime);
        //    transform.rotation(moveDir * speed * Time.deltaTime);

        //}
    }
    

  

    void Update()
    {

        



        const float MIN_X = 0.0f;
        const float MAX_X = 360.0f;
        const float MIN_Y = -60.0f;
        const float MAX_Y = 60.0f;

        X += Input.GetAxis("Mouse X") * (Sensitivity * Time.deltaTime);
        if (X < MIN_X) X += MAX_X;
        else if (X > MAX_X) X -= MAX_X;
        Y -= Input.GetAxis("Mouse Y") * (Sensitivity * Time.deltaTime);
        if (Y < MIN_Y) Y = MIN_Y;
        else if (Y > MAX_Y) Y = MAX_Y;

        transform.rotation = Quaternion.Euler(Y, X, 0.0f);
    }
   
}
