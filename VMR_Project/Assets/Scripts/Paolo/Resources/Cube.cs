using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Vector3 frictionForce;
    private double mass;

    public Vector dyn;
    public Vector weight;
    public Vector vel;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Getters and setters for velocity, mass and friction force
    public void setFrictionForce(Vector3 frictionForce)
    {
        this.frictionForce = frictionForce;
    }
    public Vector3 getVelocity() => rb.velocity;
    public Vector3 getFrictionForce() => this.frictionForce;
    public void setMass(double mass)
    {
        this.mass = mass;
    }
}
