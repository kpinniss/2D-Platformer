
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //point value for jump height
    public float JumpHeight;
    //movement speed for player
    public float MoveSpeed;
    //animator refrence
    private Animator Anim;
    //player is moving true/ false
    private bool PlayerMoving;
    //vlaue for last move 
    private Vector2 LastMove;
    //get RigidBody component
    private Rigidbody2D PlayerBody;
    //
    private Collider2D PlayerCollision;

    private static bool PlayerExists;
    //projectiles
    public Transform FirePoint;
    public GameObject projectile;

    //is player attacking
    private bool PlayerAttacking;
    public float AttackTime;
    private float AttackTimeCounter;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Player Initiated...");
        //get player animations
        Anim = GetComponent<Animator>();
        //get player rigidbodyProperties
        PlayerBody = GetComponent<Rigidbody2D>();
        //get player collsion
        PlayerCollision = GetComponent<Collider2D>();
        //carry ucrrent player instance to new levels
        if (!PlayerExists)
        {
            PlayerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        bool collision = PlayerCollision.IsTouching(PlayerCollision);
        //player is idel when not moving
        PlayerMoving = false;
        if (!PlayerAttacking)
        {
            //player projectile
            if (Input.GetKeyDown(KeyCode.R))
            {
                Instantiate(projectile, FirePoint.position, FirePoint.rotation);
            }

            //player  movement events
            if (moveX > 0.3f || moveX < -0.3f)
            {
                PlayerBody.velocity = new Vector2(moveX * MoveSpeed, 0f);
                //if input then player is moving...
                PlayerMoving = true;
                //last move is horizantal x - or +
                LastMove = new Vector2(moveX * MoveSpeed, 0f);
                if(moveX > 0.3f)
                {

                    FirePoint.transform.position = new Vector2(PlayerBody.transform.position.x + 0.30f, PlayerBody.transform.position.y);
                }
                if (moveX < -0.3f)
                {
                    FirePoint.transform.position = new Vector2(PlayerBody.transform.position.x + -0.30f, PlayerBody.transform.position.y);
                }

            }
            if (moveY > 0.3f || moveY < -0.3f)
            {
               
                PlayerBody.velocity = new Vector2(0f, moveY * MoveSpeed);
                PlayerMoving = true;
                //last move is vertical y - or +
                LastMove = new Vector2(0f, moveY * MoveSpeed);
                if (moveY > 0.3f)
                {
                    FirePoint.transform.position = new Vector2(PlayerBody.transform.position.x, PlayerBody.transform.position.y + 0.50f);
                }
                if (moveY < -0.3f)
                {
                    FirePoint.transform.position = new Vector2(PlayerBody.transform.position.x, PlayerBody.transform.position.y + -0.50f);
                    
                }

            }

            if (moveX < 0.3f && moveX > -0.3f)
            {
                PlayerBody.velocity = new Vector2(0f, PlayerBody.velocity.y);
            }
            if (moveY < 0.3f && moveY > -0.3f)
            {
                PlayerBody.velocity = new Vector2(PlayerBody.velocity.x, 0f);
            }

            //jump control
            var keyDown_space = Input.GetKeyDown(KeyCode.Space);

            if (keyDown_space)
            {
                PlayerBody.velocity = new Vector2(PlayerBody.velocity.x, JumpHeight);
                //AttackTimeCounter = AttackTime;
                //PlayerAttacking = true;
                //PlayerBody.velocity = Vector2.zero;
                //Anim.SetBool("Attacking", true);
                //Instantiate(projectile, FirePoint.position, FirePoint.rotation);
            }
        }

        if(AttackTimeCounter >= 0)
        {
            AttackTimeCounter -= Time.deltaTime;
           

        }
        if(AttackTimeCounter <= 0)
        {
            PlayerAttacking = false;
            Anim.SetBool("Attacking", false);
        }
        //animations on movement
        Anim.SetFloat("MoveX", moveX);
        Anim.SetFloat("MoveY", moveY);
        Anim.SetBool("PlayerMoving", PlayerMoving);
        Anim.SetFloat("LastMoveX", LastMove.x);
        Anim.SetFloat("LastMoveY", LastMove.y);

    }
   
}
