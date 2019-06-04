using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastFramePosition;
    private GameObject explosion;

    //public GameObject blueVector;
    //public GameObject redVector;
    //public GameObject sphere;
    //private float originalRedVectorIntensity;

    private Rigidbody otherRb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        otherRb = GameObject.Find("BigPlanet").GetComponent<Rigidbody>();
        //GravityManager.planetsRigidbodies.Add(rb);

        // lastFramePosition = transform.position;

        //transform.Find("Trail").GetComponent<TrailRenderer>().startColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        explosion = Resources.Load<GameObject>("PoffAnimation");

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

                this.transform.rotation = Quaternion.LookRotation(otherRb.transform.position - this.transform.position);

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


        /*if (Vector3.Distance(transform.position, otherRb.transform.position) > 35f)
            Explode();*/


    }

    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        //GravityManager.planetsRigidbodies.Remove(rb);
    }
}
