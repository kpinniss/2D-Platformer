using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        public PlayerMovment Player;
        public bool IsTracking;
        public float Xoffset;
        public float Yoffset;
        private void Start()
        {
            Player = FindObjectOfType<PlayerMovment>();
            IsTracking = true;
        }

        private void Update()
        {
            if(IsTracking)
            {
                var playerPOS = Player.transform.position;
                transform.position = new Vector3(playerPOS.x + Xoffset, playerPOS.y + Yoffset, transform.position.z);
            }
        }

    }
}
