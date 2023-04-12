using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    public float gravityScale = 5;
    float jumpTime;
    float jumpForce;
    bool jumping;
    bool jumpCancelled;
    public float distanceToCheck;
    public bool isGrounded;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        distanceToCheck = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToCheck + 0.1f);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale));
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);

        if(jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector3.down * cancelRate);
        }
    }

}
