using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class HurtEnemy : MonoBehaviour 
    {
        public int DamageToGive;
        public GameObject DamageEffect;
        public Transform HitPoint;

        private void Start()
        {
            
        }

        private void Update()
        {
               
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(DamageToGive);
                Instantiate(DamageEffect, HitPoint.position, HitPoint.rotation);
            }
        }
    }
}
