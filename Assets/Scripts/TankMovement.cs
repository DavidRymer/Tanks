using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Shooter;

public class TankMovement : MonoBehaviour
{
    public float speed = 3f;
    public GameObject bullet;
    private Shoot _bullet;
    private PhotonView photonView;


    void Start()
    {
        _bullet = transform.Find("Body").Find("Gun Pivot").Find("Gun").Find("ShootingPoint").gameObject
            .AddComponent<Shoot>();
//        _bullet.bullets = transform.Find("Body").Find("Gun Pivot").Find("Gun").Find("ShootingPoint").Find("Ammo")
//            .GetComponentsInChildren<Transform>().ToList();
//        photonView = gameObject.GetPhotonView();
//
        _bullet.bullet = bullet;
  }

    private void FixedUpdate()
    {
        BodyMovement();
        GunMovement();
    }

    void RotateGun(int z)
    {
        transform.Find("Body").Find("Gun Pivot").eulerAngles = new Vector3(0, 0, z);
    }

    void GunMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RotateGun(270);
            _bullet.Fire(Vector2.up, 0);
            
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateGun(0);
            _bullet.Fire(Vector2.left, 90);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RotateGun(90);
            _bullet.Fire(Vector2.down, 180);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateGun(180);
            _bullet.Fire(Vector2.right, 270);
        }
    }

    void BodyMovement()
    {
        GunMovement();

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            transform.Find("Body").eulerAngles = new Vector3(0, 0, 0);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
            transform.Find("Body").eulerAngles = new Vector3(0, 0, 90);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            transform.Find("Body").eulerAngles = new Vector3(0, 0, 180);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
            transform.Find("Body").eulerAngles = new Vector3(0, 0, 270);
        }
    }
}