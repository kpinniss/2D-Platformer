using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text HPText;

    public Slider HealthBar;

    public PlayerHealthManager PlayerHealth;
    //
    private static bool UI_Exists;
	// Use this for initialization
	void Start () {
        if (!UI_Exists)
        {
            UI_Exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
       
        HealthBar.maxValue = PlayerHealth.MaxHealth;
        HealthBar.value = PlayerHealth.CurrentHealth;

        HPText.text = "Health: " + PlayerHealth.CurrentHealth + " / " + PlayerHealth.MaxHealth;
       
	}
}
