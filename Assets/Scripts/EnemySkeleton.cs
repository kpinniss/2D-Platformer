using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySkeleton : MonoBehaviour {

    public float MoveSpeed;
    private Rigidbody2D EnemyBody;
    private bool Moving;
    public float TimeBetweenMove;
    private float TimeBetweenMoveCounter;
    public float MoveTime;
    private float MoveTimeCounter;
    private Vector3 MoveDirection;
    public float WaitToReload;
    private bool Reloading;
    private GameObject ThePlayer;
    

	// Use this for initialization
	void Start () {
        EnemyBody = GetComponent<Rigidbody2D>();
        //TimeBetweenMoveCounter = TimeBetweenMove;
        //MoveTimeCounter = MoveTime;
        MoveTimeCounter = Random.Range(MoveTime * 0.75f, TimeBetweenMove * 1.25f);
        TimeBetweenMoveCounter = Random.Range(TimeBetweenMove * 0.75f, TimeBetweenMove * 1.25f);


	}
	
	// Update is called once per frame
	void Update () {
        if (Moving)
        {
            MoveTimeCounter -= Time.deltaTime;
            EnemyBody.velocity = MoveDirection;
            if(MoveTimeCounter < 0f)
            {
                Moving = false;
                //TimeBetweenMoveCounter = TimeBetweenMove;
                MoveTimeCounter = Random.Range(MoveTime * 0.75f, TimeBetweenMove * 1.25f);
            }
        }
        else
        {
            TimeBetweenMoveCounter -= Time.deltaTime;
            EnemyBody.velocity = Vector2.zero;
            if(TimeBetweenMoveCounter < 0f)
            {
                Moving = true;
                //MoveTimeCounter = MoveTime;
                TimeBetweenMoveCounter = Random.Range(TimeBetweenMove * 0.75f, TimeBetweenMove * 1.25f);
                MoveDirection = new Vector3(Random.Range(-1f, 1f) *MoveSpeed, Random.Range(-1f, 1f) *MoveSpeed, 0f);
            }
            
        }
        //reload player
        //if (Reloading)
        //{
        //    WaitToReload -= Time.deltaTime;
        //    if(WaitToReload < 0f)
        //    {
        //        SceneManager.LoadScene(Application.loadedLevel);
        //        ThePlayer.SetActive(true);
        //    }
        //}
	}
    //kill player on collide
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if(other.gameObject.name == "player")
    //    {
    //        //Destroy(other.gameObject);
    //        other.gameObject.SetActive(false);
    //        Reloading = true;
    //        ThePlayer = other.gameObject;
    //    }
    //}
}
