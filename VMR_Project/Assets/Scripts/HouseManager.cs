using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    private BoxCollider[] colliders;

    void Start()
    {
        colliders = GetComponentsInChildren<BoxCollider>();
    }

    public void SetMaterial(PhysicMaterial material)
    {   
        foreach(BoxCollider col in colliders)
        {
            col.material = material;
        }
    }
}
