using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Timers;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Networking;

namespace Shooter

{
    public class Shoot : MonoBehaviour
    {
        public GameObject bullet;
        public int tickDelayPerShot = 20;
        private int shootTimer = 0;

        void Start()
        {
        }

        void FixedUpdate()
        {
            shootTimer += 1;
        }


        public void Fire(Vector2 direction, int rotation)
        {
            if (shootTimer > tickDelayPerShot)
            {
                GameObject projectile = PhotonNetwork.Instantiate(bullet.name, transform.position, Quaternion.identity,0);
                projectile.transform.eulerAngles = new Vector3(0, 0, rotation);
                projectile.AddComponent<Rigidbody2D>().isKinematic = true;
                projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f;
                shootTimer = 0;
            }
        }
    }
}