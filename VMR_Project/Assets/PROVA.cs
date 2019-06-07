using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROVA : MonoBehaviour
{
    public GameObject cube;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            cube.GetComponent<Rigidbody>().isKinematic = false;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            cube.GetComponent<Rigidbody>().isKinematic = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(0, 0, -1);
        }
    }
}
