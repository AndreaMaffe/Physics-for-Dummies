using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotational : MonoBehaviour
{
    private ActivateDeactivatePhysics a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // transform.RotateAround(transform.position, transform.up, 20 * Time.deltaTime);
            transform.Rotate(0f, 120f, 0f);
            //transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 45f, 0f));
            Debug.Log("ciao");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        a.Activate(other.gameObject.GetComponent<Rigidbody>());
    }
}
