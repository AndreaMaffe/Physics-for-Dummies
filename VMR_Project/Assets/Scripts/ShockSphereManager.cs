using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockSphereManager : InteractiveObject
{
    private Rigidbody rb;
    private float scale;
    public float amount;
    public Transform otherSphere;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scale = 1f;
        Vector3 direction = otherSphere.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
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

    protected override void OnClick()
    {
        rb.AddForce(transform.forward * amount, ForceMode.VelocityChange);
    }

   
   
}
