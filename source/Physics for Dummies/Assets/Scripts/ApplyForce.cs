using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 direction;
    public float amount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * amount, ForceMode.Impulse);
    }
    
}
