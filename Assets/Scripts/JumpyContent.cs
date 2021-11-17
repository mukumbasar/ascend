using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyContent : MonoBehaviour
{

    private float boxcastExtra = 0.2f;
    private BoxCollider2D boxCollider2d;
    private Rigidbody2D rb;
    public float jumpValueX = 6f;
    public float jumpValueY = 6f;
    public LayerMask platformMask;

    private Vector3 Flipper = new Vector3(0, 180, 0);
    private bool isFacingRight;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        isFacingRight = true;
    }
    private void Update()
    {
        
        IsGrounded();

        //these two flip player object for accurate jumping

        if(Input.GetKeyDown(KeyCode.A) && isFacingRight)
        {
            transform.Rotate(Flipper);
            isFacingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isFacingRight)
        {
            transform.Rotate(Flipper);
            isFacingRight = true;
        }

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            jumpValueY += 0.1f;
        }

        if(Input.GetKeyUp(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpValueY);
        }

    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down,
            boxcastExtra, platformMask);

        Color rayColor;

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
        return raycastHit.collider != null;
    }
}
