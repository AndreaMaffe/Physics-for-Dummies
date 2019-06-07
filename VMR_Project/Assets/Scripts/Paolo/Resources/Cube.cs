using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Vector dyn;
    public Vector weight;
    public Vector vel;
    public Vector tanWeight;

    private Rigidbody rb;
    private float mass;
    private float factorScale;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private float startMass;
    private Vector3 startScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
        startMass = rb.mass;
        factorScale = (float)0.05;
        startPosition = this.transform.localPosition;
        Debug.Log("Start Position: " + startPosition);
        startRotation = this.transform.localRotation;
        Debug.Log("Start Rotation: " + startRotation);
        startScale = this.transform.localScale;
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
        if (Input.GetKeyDown(KeyCode.M) && rb.mass < 20)
        {
            rb.mass++;
            this.transform.localScale += new Vector3(0.04f, 0, 0);
            this.transform.position += new Vector3(-0.03f, 0.01f, 0);
        }
        if (Input.GetKeyDown(KeyCode.N) && rb.mass > 1)
        {
            rb.mass--;
            this.transform.localScale -= new Vector3(0.04f, 0, 0);
            this.transform.position -= new Vector3(-0.03f, 0.01f, 0);
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

    // Move the cube again on top of the ramp
    public void CreateCube()
    {
        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);
        this.transform.localPosition = startPosition;
        this.transform.localRotation = startRotation;
        this.transform.localScale = startScale;
        this.GetComponent<Rigidbody>().mass = startMass;
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        this.vel.SetScale(0);
        this.dyn.SetScale(0);
    }
}

