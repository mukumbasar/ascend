using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyContent : MonoBehaviour
{

    private float boxcastExtra = 0.2f;
    private BoxCollider2D boxCollider2d;
    private Rigidbody2D rb;
    public float jumpValue;
    public LayerMask platformMask;
    
    private Vector3 Flipper = new Vector3(0, 180, 0);
    
    private bool isFacingRight;
    private bool jumpValueEnhancing;
    private bool rightJump;
    private bool leftJump;

    public PhysicsMaterial2D normalMat, bouncyMat;

    private Animator animator;
    private bool jumpAnimation;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        isFacingRight = true;
        rightJump = false;
        leftJump = false;
        animator = GetComponent<Animator>();
        
        
    }
   

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpValueEnhancing = true;
            


        }

        if (jumpValue >= 12f && IsGrounded() && isFacingRight)
        {
            rightJump = true;
            



        }

        if (jumpValue >= 12f && IsGrounded() && !isFacingRight)
        {
            leftJump = true;
            


        }

        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded() && isFacingRight)
        {
            rightJump = true;
            


        }
        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded() && !isFacingRight)
        {
            leftJump = true;
            

        }
    }

    private void ResetJumpValue()
    {
        jumpValue = 0f;
    }

    private void FlipPlayer()
    {
        if (Input.GetKeyDown(KeyCode.A) && isFacingRight)
        {
            transform.Rotate(Flipper);
            isFacingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isFacingRight)
        {
            transform.Rotate(Flipper);
            isFacingRight = true;
        }
    }


    bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down,
            boxcastExtra, platformMask);

        /* Color rayColor;

        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x, 0), 
            Vector2.down * (boxCollider2d.bounds.extents.y + boxcastExtra), rayColor);
        Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, 0),
           Vector2.down * (boxCollider2d.bounds.extents.y + boxcastExtra), rayColor);
        Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, boxCollider2d.bounds.extents.y + boxcastExtra),
           Vector2.right * (2* boxCollider2d.bounds.extents.x), rayColor);
        Debug.Log(raycastHit.collider);
        */
        return raycastHit.collider != null;
    }
    private void MaterialChanger()
    {
        if (!IsGrounded())
        {
            rb.sharedMaterial = bouncyMat;
            
           
            
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }
    }

  

    private void FixedUpdate()
    {
        if(jumpValueEnhancing)
        {
            jumpValue += 0.4f;
            animator.SetFloat("holdingjump", jumpValue);
            
        }
        if(rightJump)
        {
            float tempValue = jumpValue;
            rb.velocity = new Vector2(0.6f*tempValue, 1.8f*tempValue);
            jumpValueEnhancing = false;
            rightJump = false;
            ResetJumpValue();
            animator.SetFloat("holdingjump", jumpValue);

        }
        if(leftJump)
        { 
            float tempValue = jumpValue;
            rb.velocity = new Vector2(-0.6f*tempValue, 1.8f*tempValue);
            jumpValueEnhancing = false;
            leftJump = false;
            ResetJumpValue();
            animator.SetFloat("holdingjump", jumpValue);


        }
    }

    private void Update()
    {
        //changes the physics material of the character in air to enable wall bouncing and achieve stable landing
        MaterialChanger();

        //flips the character for accurate jumping
        FlipPlayer();

        //makes the character jump, duh
        Jump();

        

    }

   
}
