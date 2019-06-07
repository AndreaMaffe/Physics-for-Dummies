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
        factorScale = (float)0.05;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
        SetScaleMass();

        if(this.GetComponent<Rigidbody>().velocity.magnitude > 0)
            vel.SetScale(this.GetComponent<Rigidbody>().velocity.magnitude * (factorScale * 5));
        weight.SetScale((this.GetComponent<Rigidbody>().mass * Physics.gravity.magnitude) * factorScale);
        tanWeight.SetScale((this.GetComponent<Rigidbody>().mass * Physics.gravity.magnitude * Mathf.Sin(Mathf.PI / 4)) * factorScale);
    }

    // Mass management methods
    public void SetScaleMass()
    {
        if (Input.GetKeyDown(KeyCode.M) && mass < 20)
        {
            mass++;
            rb.mass = mass;
            this.transform.localScale += new Vector3(0.4f, 0, 0);
            this.transform.position += new Vector3(-0.02f, 0.012f, 0);
        }
        if (Input.GetKeyDown(KeyCode.N) && mass > 1)
        {
            mass--;
            rb.mass = mass;
            this.transform.localScale -= new Vector3(0.4f, 0, 0);
            this.transform.position -= new Vector3(-0.02f, 0.012f, 0);
        }
    }
    public float GetMass() => mass;

    // Friction force computation
    public float DynFrictionForceComputation(double dynFrictionCohefficient, float mass, Vector3 velocity) =>
        (((float)dynFrictionCohefficient) * mass * Physics.gravity.magnitude * Mathf.Sin(Mathf.PI / 4) * velocity / velocity.magnitude).magnitude;
    public void DynSetScale(float scale)
    {
        dyn.SetScale(scale * (factorScale * (float)2.5));
    }
}

