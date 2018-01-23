using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCloneObejct : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name.Contains("Clone"))
        {
            float time = 5.0f;
            Destroy(gameObject,time);
        }
	}
}
