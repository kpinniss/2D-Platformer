using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject CurrentCheckPoint;
    public CameraController _camera;
    private PlayerMovment Player;
    public GameObject DeathEffect;
    public GameObject RespawnEffect;
    public float RespawnDelay;
    private float gravity_store;
    // Use this for initialization
    void Start () {
        Player = FindObjectOfType<PlayerMovment>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KillAndRespawn()
    {
        
        StartCoroutine("KillAndRespawnCo");
       
    }

    public IEnumerator KillAndRespawnCo()
    {
        StartKill();
        yield return new WaitForSeconds(RespawnDelay);
        RevivePlayer();
    }
    public void StartKill()
    {
        gravity_store = Player.GetComponent<Rigidbody2D>().gravityScale;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        KillPlayer();
    }
    public void KillPlayer()
    {
        Debug.Log("Player Killed");
        Debug.Log(Player.GetComponent<Rigidbody2D>().gravityScale);
        Debug.Log(gravity_store);
        _camera.IsTracking = false;
        Instantiate(DeathEffect, Player.transform.position, Player.transform.rotation);
        Player.enabled = false;
        Player.GetComponent<Renderer>().enabled = false;

    }

    public void RevivePlayer()
    {
        Debug.Log("Player Respawned");
        Player.transform.position = CurrentCheckPoint.transform.position;
        Instantiate(RespawnEffect, Player.transform.position, Player.transform.rotation);
        Player.enabled = true;
        Player.GetComponent<Renderer>().enabled = true;
        _camera.IsTracking = true;
        Player.GetComponent<Rigidbody2D>().gravityScale = gravity_store;
        if(Player.GetComponent<Rigidbody2D>().gravityScale <= 0f)
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 3f;
        }
    }

   
}
