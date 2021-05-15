using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float onscreenDelay = 3f;
 
    void Start () 
    {
        Destroy(gameObject, onscreenDelay);
    }
}
