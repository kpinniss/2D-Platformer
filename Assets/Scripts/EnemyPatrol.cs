using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float MoveSpeed;

    public bool MoveRight;

    //wall checking
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask WhatIsWall;
    private bool HitWall;

    private bool NotAtEdge;
    public Transform edgeCheck;


    // Use this for initialization
    void Start () {
        var _enemyBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        HitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, WhatIsWall);
        NotAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, WhatIsWall);
        if (HitWall || !NotAtEdge)
        {
            MoveRight = !MoveRight;
        }

        var _enemyBody = GetComponent<Rigidbody2D>();
        
        if (MoveRight)
        {
            transform.localScale = new Vector3(-.75f, .75f, .75f);
            _enemyBody.velocity = new Vector2(MoveSpeed, _enemyBody.velocity.y);

           
        }
        else
        {
            transform.localScale = new Vector3(.75f, .75f, .75f);
            _enemyBody.velocity = new Vector2(-MoveSpeed, _enemyBody.velocity.y);
        }
    }
}
