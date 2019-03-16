using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject bulletHit;
    public PhotonView photonView;


    private int timer = 0;
    public int bulletDelayTicks = 200;

    void Start()
    {
        Destroy(gameObject, 2);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Rocket"))
        {
            Debug.Log(other.gameObject.CompareTag("Rocket"));
            GameObject explosion =
                PhotonNetwork.Instantiate(bulletHit.name, transform.position, Quaternion.identity, 0);
        }
        
        Debug.Log(other.gameObject.CompareTag("Rocket") + "dddddddddddd");



        if (photonView.isMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}