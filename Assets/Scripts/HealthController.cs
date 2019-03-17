using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : Photon.PunBehaviour
{
    public GameObject healthBar;
    public int health = 100;
    public int damage = 5;
    public GameObject tankExplosion;

    [PunRPC]
    void TakeDamage()
    {
        Vector3 bar = healthBar.transform.Find("Bar").localScale;

        if (health - damage >= 0)
        {
            health -= damage;
            
        }
        else
        {
            health = 0;
            PhotonNetwork.Instantiate(tankExplosion.name, transform.position, Quaternion.identity, 0);
            gameObject.SetActive(false);
        }
        
        healthBar.transform.Find("Bar").localScale = new Vector3(3.1f * health / 100f, bar.y, bar.z);
    }
    
    


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            photonView.RPC("TakeDamage", PhotonTargets.All);
        }
    }
}