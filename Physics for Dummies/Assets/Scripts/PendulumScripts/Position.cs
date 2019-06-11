using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    private float previousPosition;
    public GameObject pendulumBody;

    private void Start()
    {
        previousPosition = pendulumBody.transform.position.y + 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pendulumBody.transform.position.y != previousPosition)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, pendulumBody.transform.position.y + 2f, this.gameObject.transform.position.z);
        }
    }
}
