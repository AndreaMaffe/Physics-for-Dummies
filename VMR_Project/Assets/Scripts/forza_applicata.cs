using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forza_applicata : MonoBehaviour
{

    private Rigidbody rb;
    public Vector3 direction;
    public float amount;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction*amount, ForceMode.Impulse);
    }




}
