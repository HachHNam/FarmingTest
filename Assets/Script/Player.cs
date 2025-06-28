using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{  
    //Moving
    private float horizontal;
    public float speed;
    private SpriteRenderer sr;
    //Jumping
    private Rigidbody2D rb;
    public LayerMask whatIsGround;
    public bool onGround;
    public float jumpForce;
    public bool doublejump = false;
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            sr.flipX = false;
        }
        if (horizontal < 0)
        {
            transform.position += -Vector3.right * speed * Time.deltaTime;
            sr.flipX = true;
        }
    }

    void Jump()
    {
        onGround = Physics2D.Raycast(transform.position, Vector3.down, 0.7f, whatIsGround);
         //Debug.Log(doublejump);
        if(onGround && !Input.GetKey(KeyCode.Space))
        {
            doublejump = false;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(onGround || doublejump)
            {
                rb.velocity = Vector3.up * jumpForce;
                doublejump = !doublejump;
               // Debug.Log(doublejump);
               
            }
        }
    }
    
}
