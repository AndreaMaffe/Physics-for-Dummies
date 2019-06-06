using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityIndicator : MonoBehaviour
{ 

    private Rigidbody rb;
    public Vector vector_script;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        Vector3 newRotation = Quaternion.LookRotation(rb.velocity).eulerAngles + Quaternion.Euler(90f, 0f, 0f).eulerAngles;
        vector_script.gameObject.transform.rotation = Quaternion.Euler(newRotation);
        vector_script.SetScale(rb.velocity.magnitude * 0.2f);

    }

}