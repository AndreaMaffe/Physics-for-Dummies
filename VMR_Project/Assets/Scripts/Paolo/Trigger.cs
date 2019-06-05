using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>().isKinematic)
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //other.gameObject.GetComponent<>().isKinematic = true;
        }
    }
}
