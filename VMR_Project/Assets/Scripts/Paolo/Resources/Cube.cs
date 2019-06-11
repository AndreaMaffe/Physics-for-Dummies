using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : InteractiveObject
{
    public Vector dyn;
    public Vector weight;
    public Vector vel;
    public Vector tanWeight;
    public Incline incline;
    public GameObject interactableObject;

    private Rigidbody rb;
    private float dynFrictionForce;
    private float factorScale;
    private float startMass;
    private Vector3 startPosition;
    private Vector3 startScale;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);
        rb = GetComponent<Rigidbody>();
        factorScale = (float)0.02;
        startPosition = this.transform.localPosition;
        startRotation = this.transform.localRotation;
        startScale = transform.localScale;
        startMass = rb.mass;

        this.dyn.SetScale(0);
        this.vel.SetScale(0);
        this.tanWeight.SetScale(rb.mass * Mathf.Sin(incline.GetRotation() * (Mathf.PI / 180)) * factorScale);
        this.weight.SetScale(rb.mass * factorScale);
    }

    // Fixedupdated, called oce every fixed time instance
    void FixedUpdate()
    {
        dynFrictionForce = this.DynFrictionForceComputation(incline.GetComponent<BoxCollider>().material.dynamicFriction, rb.mass, rb.velocity);
        this.DynSetScale(dynFrictionForce);

        if (rb.velocity.magnitude > 0)
        {
            vel.SetScale(rb.velocity.magnitude * (factorScale * (float)6));
        } else
        {
            vel.SetScale(0);
        }
            
        weight.SetScale((rb.mass * Physics.gravity.magnitude) * factorScale);
        tanWeight.SetScale((rb.mass * Physics.gravity.magnitude * Mathf.Sin(incline.GetRotation() * (Mathf.PI / 180))) * factorScale);

    }

    // Friction force computation
    public float DynFrictionForceComputation(double dynFrictionCohefficient, float mass, Vector3 velocity) =>
        (((float)dynFrictionCohefficient) * mass * Physics.gravity.magnitude * Mathf.Sin(incline.GetRotation() * (Mathf.PI / 180)));
    public void DynSetScale(float scale)
    {
        dyn.SetScale(scale * (factorScale * (float)3.5));
    }

    // Vector inclination correction
    public void WeightAngleCorrection(Vector vector, Quaternion rotation)
    {
        vector.transform.localRotation = rotation;
    }

    public override void OnClick()
    {
    }
    public override void OnArrowUp()
    {
        if (focused && rb.mass < 20)
        {
            rb.mass++;
            this.transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
            this.transform.position += new Vector3(-0.02f, 0.01f, 0);
            startPosition += new Vector3(-0.02f, 0.01f, 0);
        }
    }
    public override void OnArrowDown()
    {
        if (focused && rb.mass > 1)
        {
            rb.mass--;
            this.transform.localScale -= new Vector3(0.04f, 0.04f, 0.04f);
            this.transform.position -= new Vector3(-0.02f, 0.01f, 0);
            startPosition -= new Vector3(-0.02f, 0.01f, 0);
        }
    }
    public void OnDisable()
    {
        rb.mass = startMass;
        transform.localScale = startScale;
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
        vel.SetScale(0);
        dyn.SetScale(0);
        tanWeight.SetScale(rb.mass * Mathf.Sin(incline.GetRotation() * (Mathf.PI / 180)) * factorScale);
        weight.SetScale(rb.mass * factorScale);
        interactableObject.SetActive(true);
    }
    public void ReturnToInitialPosition()
    {
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
        vel.SetScale(0);
        dyn.SetScale(0);
        tanWeight.SetScale((rb.mass * Physics.gravity.magnitude * Mathf.Sin(incline.GetRotation() * (Mathf.PI / 180))) * factorScale);
        weight.SetScale(rb.mass * factorScale);
        interactableObject.SetActive(true);
    }
}

