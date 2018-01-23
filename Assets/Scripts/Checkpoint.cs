using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public LevelManager _lvlMngr;
    // Use this for initialization
    void Start()
    {
        _lvlMngr = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            //Destroy(collision.gameObject);
            _lvlMngr.CurrentCheckPoint = gameObject;
            Debug.Log("Hit CheckPoint");
        }
    }
}



