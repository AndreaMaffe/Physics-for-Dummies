using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float mass;
    private float factorScale;

    public Vector dyn;
    public Vector weight;
    public Vector vel;
    public Vector tanWeight;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
        factorScale = (float)0.2;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
        if (Input.GetKeyDown(KeyCode.M))
        {
            mass++;
            rb.mass = mass;
        }
        vel.SetScale(this.GetComponent<Rigidbody>().velocity.magnitude);
        weight.SetScale((this.GetComponent<Rigidbody>().mass * Physics.gravity.magnitude) * factorScale);
        tanWeight.SetScale((this.GetComponent<Rigidbody>().mass * Physics.gravity.magnitude * Mathf.Sin(Mathf.PI / 4)) * factorScale);
        Debug.Log("Tan Weight force: " + this.GetComponent<Rigidbody>().mass * Physics.gravity.magnitude * Mathf.Sin(Mathf.PI / 4));
    }

    public void SetMass(float mass)
    {
        rb.mass = mass;
    }

    // Friction force computation
    public float DynFrictionForceComputation(double dynFrictionCohefficient, float mass, Vector3 velocity) =>
        (((float)dynFrictionCohefficient) * mass * Physics.gravity.magnitude * Mathf.Sin(Mathf.PI / 4) * velocity / velocity.magnitude).magnitude;
    public void DynSetScale(float scale)
    {
        dyn.SetScale(scale * factorScale);
        //Debug.Log("Dynamic friction force: " + scale);
    }
}

