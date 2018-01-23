using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class DamageEnemy : MonoBehaviour
    {
        
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
