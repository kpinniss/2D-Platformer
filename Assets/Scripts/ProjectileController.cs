using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ProjectileController : MonoBehaviour
{

    public float speed;
    public PlayerMovment Player;
    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<PlayerMovment>();

        if(Player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
