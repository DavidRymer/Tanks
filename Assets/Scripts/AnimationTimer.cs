using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimer : MonoBehaviour
{
    public float explosionTimer = 0.1f;
    
    void Start()
    {
        Destroy(gameObject, explosionTimer);
    }


}
