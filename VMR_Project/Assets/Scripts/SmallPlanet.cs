using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlanet : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastFramePosition;
    private float initialForce;

    public GameObject planet;
    public GameObject redVector;
    public GameObject blueVector;

    public float scaleFactor;

    public Rigidbody otherRb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        lastFramePosition = transform.position;


        float initialDistance = (otherRb.transform.position - rb.transform.position).magnitude;
        initialForce = (rb.mass * otherRb.mass) / (initialDistance * initialDistance);
    }


    void FixedUpdate()
    {
        Vector3 direction = otherRb.transform.position - rb.transform.position;
        float distance = direction.magnitude;
        float forceMagnitude = (rb.mass * otherRb.mass) / (distance * distance);

        rb.AddForce(direction.normalized * forceMagnitude, ForceMode.Acceleration);

 
        //vector.transform.localScale = new Vector3(1, 1, 1) * forceMagnitude / initialMagnitude;
        //}
        //}

        
        Vector3 linearVelocity = transform.position - lastFramePosition;
        planet.transform.rotation = Quaternion.LookRotation(otherRb.transform.position - this.transform.position);

        blueVector.transform.localPosition = linearVelocity.normalized;
        blueVector.transform.localRotation = Quaternion.LookRotation(linearVelocity - blueVector.transform.localPosition);
        blueVector.transform.localRotation *= (Quaternion.Euler(-90, 0, 0));

        blueVector.GetComponent<Vector>().SetScale(scaleFactor * rb.velocity.magnitude);
        redVector.GetComponent<Vector>().SetScale(forceMagnitude / initialForce);

        lastFramePosition = this.transform.position;
        
    }
}
