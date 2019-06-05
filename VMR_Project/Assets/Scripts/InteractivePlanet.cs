using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePlanet : InteractiveObject
{
    private Rigidbody rb;
    private Vector3 lastFramePosition;
    private Vector3 originalPosition;
    private GameObject explosion;

    private float scale;

    public GameObject blueVector;

    public Rigidbody otherRb;
    public float amount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        originalPosition = this.transform.position;
        lastFramePosition = transform.position;

        explosion = Resources.Load<GameObject>("PoffAnimation");
        scale = 1f;
        blueVector.gameObject.SetActive(false);
    }


    void FixedUpdate()
    {                
        Vector3 direction = otherRb.transform.position - rb.transform.position;
        float distance = direction.magnitude;
        float forceMagnitude = (rb.mass * otherRb.mass) / (distance * distance);

        rb.AddForce(direction.normalized * forceMagnitude, ForceMode.Acceleration);

        Vector3 linearVelocity = transform.position - lastFramePosition;
        //planet.transform.rotation = Quaternion.LookRotation(otherRb.transform.position - this.transform.position);

        blueVector.transform.localPosition = linearVelocity.normalized;
        blueVector.transform.localRotation = Quaternion.LookRotation(linearVelocity - blueVector.transform.localPosition);
        blueVector.transform.localRotation *= (Quaternion.Euler(-90, 0, 0));

        blueVector.GetComponent<Vector>().SetScale(0.05f * rb.velocity.magnitude);

        lastFramePosition = this.transform.position;

        if (Vector3.Distance(transform.position, otherRb.transform.position) > 35f)
            Explode();

        //LineDrawer.Instance.DrawDottedLine(this.transform.position, otherRb.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        rb.isKinematic = true;
        this.transform.position = originalPosition;
        blueVector.SetActive(false);
    }

    protected override void OnClick()
    {
        blueVector.SetActive(true);
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * amount, ForceMode.Impulse);
    }

    protected override void OnArrowUp()
    {
        scale += 0.2f;

        if (scale > 1.8f)
            scale = 1.8f;

        this.transform.localScale = new Vector3(scale, scale, scale);

        rb.mass += 1f;
  
        if (rb.mass > 30f)
            rb.mass = 30f;

    }

    protected override void OnArrowDown()
    {
        scale -= 0.2f;

        if (scale < 0.4f)
            scale = 0.4f;

        this.transform.localScale = new Vector3(scale, scale, scale);

        rb.mass -= 1f;

        if (rb.mass < 10f)
            rb.mass = 10f;
    }
}
