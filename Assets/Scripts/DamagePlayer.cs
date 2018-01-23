using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class DamagePlayer : MonoBehaviour 
    {
        public int attackDamage;
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "player")
            {
                other.gameObject.GetComponent<PlayerHealthManager>().DamagePlayerHealth(attackDamage);
            }
        }
    }
}
