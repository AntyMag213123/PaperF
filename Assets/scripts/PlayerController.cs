using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform GroundPoint;
    private bool isGrounded;

    public Animator anim;

    public SpriteRenderer theSR;

    private bool movingBackwards;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        theRB.velocity = transform.right * moveInput.x * moveSpeed + transform.forward * moveInput.y * moveSpeed + theRB.velocity.y * Vector3.up;

        anim.SetFloat("moveSpeed", theRB.velocity.magnitude);

        RaycastHit hit;
        if (Physics.Raycast(GroundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
        }

        anim.SetBool("onGround", isGrounded);

        if (!theSR.flipX && moveInput.x < 0)
        {
            theSR.flipX = true;
        }
        else if (theSR.flipX && moveInput.x > 0)
        {
            theSR.flipX = false;
        }

        if (!movingBackwards && moveInput.y > 0)
        {
            movingBackwards = true;
        }
        else if (movingBackwards && moveInput.y < 0)
        {
            movingBackwards = false;
        }
        anim.SetBool("movingBackwards", movingBackwards);
    }
}