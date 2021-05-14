using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    
    private float vInput;
    private float hInput;
    
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        
        transform.Translate(Vector3.forward * vInput * Time.deltaTime);

        transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }
}
