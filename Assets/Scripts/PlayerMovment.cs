using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    public float MoveSpeed;
    public float JumpHeight;
    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;
    private bool IsGrounded;
    
    //animator refrence
    private Animator Anim;
    //player is moving true/ false

    public Transform FirePoint;
    public GameObject Projectile;

    //velocity of player when moving and not moving
    private float MoveVelocity;

    //private bool DoubleJumped;
    // Use this for initialization
    void Start () {
        //get player animations
        Anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
    }
    // Update is called once per frame
    void Update () {
        var moveX = Input.GetAxis("Horizontal");
        Rigidbody2D playerBody = GetComponent<Rigidbody2D>();
        Move(playerBody);
        FireProjectile();

       
    }

    public void FireProjectile()
    {
        var fire = Input.GetKeyDown(KeyCode.Space);
        if (fire)
        {
            Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
        }
    }

    public void Move(Rigidbody2D playerbody)
    {
        var rightArrow = Input.GetKey(KeyCode.D);
        var leftArrow = Input.GetKey(KeyCode.A);
        var spaceBar = Input.GetKey(KeyCode.W);
        MoveVelocity = 0f;
        //if (IsGrounded)
        //    DoubleJumped = false;
        // DoubleJumped = IsGrounded == true ? false : IsGrounded;
        Anim.SetBool("Grounded", IsGrounded);
        //jump
        if (spaceBar && IsGrounded)
        {
            playerbody.velocity = new Vector2(playerbody.velocity.x, JumpHeight);
        }
        
        if (rightArrow)
        {
            //playerbody.velocity = new Vector2(MoveSpeed, playerbody.velocity.y);
            //PlayerMoving = true;
            MoveVelocity = MoveSpeed;
        }
        //move left
        if(leftArrow)
        {
            //playerbody.velocity = new Vector2(-MoveSpeed, playerbody.velocity.y);
            //PlayerMoving = true;
            MoveVelocity = -MoveSpeed;
        }

        playerbody.velocity = new Vector2(MoveVelocity, playerbody.velocity.y);

        Anim.SetFloat("Speed", Mathf.Abs( playerbody.velocity.x));

        if(playerbody.velocity.x > 0) 
        {
            transform.localScale = new Vector3(1.5f,1.5f,1f);
        }
        else if(playerbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
        }
       
    }
}
