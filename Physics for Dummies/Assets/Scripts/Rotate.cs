using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 axis;
    public float velocity;

    void Update()
    {
        transform.Rotate(axis * velocity);
    }
}
