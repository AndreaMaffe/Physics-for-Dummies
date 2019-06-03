using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPlanet : MonoBehaviour
{
    void Start()
    {
        GravityManager.planetsRigidbodies.Add(GetComponent<Rigidbody>());
    }
}
