using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    
    private float vInput;
    private float hInput;

    private Rigidbody _rb;
    
    private void MoveTransform(float vInput, float hInput, float deltaTime)
    {
        transform.Translate(Vector3.forward * vInput * deltaTime);

        transform.Rotate(Vector3.up * hInput * deltaTime);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation *Time.fixedDeltaTime);
        
        _rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}
