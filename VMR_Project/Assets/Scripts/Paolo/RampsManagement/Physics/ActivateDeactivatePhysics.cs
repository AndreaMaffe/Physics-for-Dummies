using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivatePhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(Rigidbody rb)
    {
        if (rb.isKinematic)
            rb.isKinematic = false;
    }
    public void Deactivate(Rigidbody rb)
    {
        if (!rb.isKinematic)
            rb.isKinematic = true;
    }
}
