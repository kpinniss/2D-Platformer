using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPickup : MonoBehaviour {

    public int points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Souls!");
        if(collision.name != "player")
        {
            return;
        }
        ScoreManager.UpdateScore(points);
        Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
