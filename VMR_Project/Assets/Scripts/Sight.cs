using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public GameObject planet;
    public float push;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.up/ 10;
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left / 10;
        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.down / 10;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right / 10;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newPlanet = Instantiate(planet, this.transform.position, Quaternion.identity);
            Vector3 direction = (this.transform.position - new Vector3(0, 0, -40)).normalized;
            newPlanet.GetComponent<Rigidbody>().AddForce(direction * push);


        }

    }
}
