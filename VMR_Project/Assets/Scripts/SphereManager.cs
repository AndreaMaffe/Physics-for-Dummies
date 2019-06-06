using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    // Start is called before the first frame update
    private SphereCollider sc;
    void Start()
    {
        sc = GetComponent<SphereCollider>();

    }

     public void SetMaterial(PhysicMaterial material)
    {
        sc.material = material;
    }
}
