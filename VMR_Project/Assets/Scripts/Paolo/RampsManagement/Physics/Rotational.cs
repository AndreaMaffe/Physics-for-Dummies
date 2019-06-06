using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotational : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
        if (Input.GetKeyDown(KeyCode.F))
            transform.Rotate(0f, 120f, 0f);
    }
}
