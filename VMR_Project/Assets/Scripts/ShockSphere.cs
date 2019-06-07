using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockSphere : InteractiveObject
{
    private Rigidbody rb;
    private float scale;
    public float amount;
    public Transform otherSphere;

    private Vector3 originalPosition;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        scale = 1f;
        Vector3 direction = otherSphere.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public override void OnArrowDown()
    {

        scale -= 0.2f;

        if (scale < 0.4f)
            scale = 0.4f;

        this.transform.localScale = new Vector3(scale, scale, scale);

        rb.mass -= 1f;

        if (rb.mass < 10f)
            rb.mass = 10f;

    }

    public override void OnArrowUp()
    {
        scale += 0.2f;

        if (scale > 1.8f)
            scale = 1.8f;

        this.transform.localScale = new Vector3(scale, scale, scale);

        rb.mass += 1f;

        if (rb.mass > 30f)
            rb.mass = 30f;
    }



    public void ResetPosition()
    {
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        transform.position = originalPosition;

    }

    public void StartAddForce()
    {
        rb.AddForce(transform.forward * amount, ForceMode.VelocityChange);
    }

    public override void OnClick()
    {
    }
}
