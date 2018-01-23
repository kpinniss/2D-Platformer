using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.Scripts
{
    class LevelStartPoint : MonoBehaviour
    {
        //player
        private PlayerController player;
        //camera
        private CameraController mainCamera;

        private void Start()
        {
            player = FindObjectOfType<PlayerController>();
            player.transform.position = transform.position;
            mainCamera = FindObjectOfType<CameraController>();
            var campos = mainCamera.transform.position;
            mainCamera.transform.position = new Vector3(campos.x, campos.y, campos.z);
        }

        private void Update()
        {
            
        }
    }
}
