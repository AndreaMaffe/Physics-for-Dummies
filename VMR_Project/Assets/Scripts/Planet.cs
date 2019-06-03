using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastFramePosition;

    //public GameObject blueVector;
    //public GameObject redVector;
    //public GameObject sphere;
    //private float originalRedVectorIntensity;

    public Rigidbody otherRb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //GravityManager.planetsRigidbodies.Add(rb);

       // lastFramePosition = transform.position;

        //transform.Find("Trail").GetComponent<TrailRenderer>().startColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }


    void FixedUpdate()
    {
        //foreach(Rigidbody otherRb in GravityManager.planetsRigidbodies)
        //{
            //if (otherRb != rb)
            //{
                
                Vector3 direction = otherRb.transform.position - rb.transform.position;
                float distance = direction.magnitude;
                float forceMagnitude = (rb.mass * otherRb.mass) / (distance * distance);

                rb.AddForce(direction.normalized * forceMagnitude, ForceMode.Acceleration);

                //sphere.transform.rotation = Quaternion.LookRotation(otherRb.centerOfMass - this.transform.position);

                //vector.transform.localScale = new Vector3(1, 1, 1) * forceMagnitude / initialMagnitude;
            //}
        //}

        /*
        Vector3 linearVelocity = transform.position - lastFramePosition;

        blueVector.transform.localPosition = linearVelocity.normalized*2;
        blueVector.transform.localRotation = Quaternion.LookRotation(linearVelocity - blueVector.transform.localPosition);
        blueVector.transform.localRotation *= Quaternion.Euler(0, 90, 180);

        lastFramePosition = this.transform.position;
        */
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        //GravityManager.planetsRigidbodies.Remove(rb);
    }
}
