using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightVector : MonoBehaviour
{
    public GameObject pendulumBody;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(pendulumBody.transform.position.x,
            pendulumBody.transform.position.y - 0.5f, pendulumBody.transform.position.z);
    }
}
