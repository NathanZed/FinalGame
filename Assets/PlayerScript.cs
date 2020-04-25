using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5.6f;
    public float gravity = -9.8f;
    public float JumpHeight = 8.6f;
    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float xMov = Input.GetAxis("Horizontal");// * speed * Time.deltaTime;
        //float yMov = Input.GetAxis("Jump") * JumpHeight * Time.deltaTime;
        float zMov = Input.GetAxis("Vertical");// * speed * Time.deltaTime;

        Vector3 move = transform.right * xMov + transform.forward * zMov;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded)
        {
            //Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //this.transform.position = new Vector3(this.transform.position.x + xMov, this.transform.position.y + yMov, this.transform.position.z + zMov);
    }
}
