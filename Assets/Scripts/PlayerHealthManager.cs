using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;
	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
	}

    public void DamagePlayerHealth(int damage)
    {
        CurrentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
