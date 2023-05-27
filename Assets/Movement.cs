using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float walkSpeed;
    public LayerMask groundMask;
    public bool canJump = true;
    public float jumpValue = 0;
    public PhysicsMaterial2D bounceMat, normalMat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var moveInput = Input.GetAxisRaw("Horizontal");
        bool isGrounded = Physics2D.OverlapBox(
            new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
            new Vector2(0.9f, 0.4f),
            0f,
            groundMask
        );

        if(!isGrounded)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }

        if(jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded && canJump)
        {
            jumpValue += 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb. velocity.y);
        }

        if (jumpValue >= 20f && isGrounded)
        {
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }
        
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0.0f; 
            }
            canJump = true;
        }
    }
    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }
}
