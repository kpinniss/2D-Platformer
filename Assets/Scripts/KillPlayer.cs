using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class KillPlayer : MonoBehaviour
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
        if(collision.name == "player")
        {
            Debug.Log("Player being killed..");
            _lvlMngr.KillAndRespawn();
        }
    }
}



