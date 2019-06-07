using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incline : MonoBehaviour
{
    public Pivot pivot;
    float originalRotation = 45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            MakeRotate();
    }

    public void MakeRotate()
    {
        originalRotation += 10f;
        transform.rotation = Quaternion.Euler(0, 0, originalRotation);
    }
}
