using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public static List<Rigidbody> planetsRigidbodies;

    private void Awake()
    {
        planetsRigidbodies = new List<Rigidbody>();
    }
}
