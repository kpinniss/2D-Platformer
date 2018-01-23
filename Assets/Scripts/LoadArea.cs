using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArea : MonoBehaviour {

    public string LevelToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D player)
    {
        try
        {
            if (player.gameObject.name == "player")
            {
                SceneManager.LoadScene(LevelToLoad);
            }
        }
        catch
        {
            Debug.Log("Could not load level.. is levelToLoad property set?");
        }
        
    }
}
