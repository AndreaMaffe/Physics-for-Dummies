using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incline : MonoBehaviour
{
    Quaternion originalRotation;
    float rotation = 45f;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            IncreaseRotation();
        if (Input.GetKeyDown(KeyCode.T))
            DecreaseRotation();
    }

    void IncreaseRotation()
    {
        if(rotation < 75f)
        {
            rotation += 5f;
            transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }
    void DecreaseRotation()
    {
        if (rotation > 35f)
        {
            rotation -= 5f;
            transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }

    public Quaternion GetOriginalRotation() => originalRotation;
    public void SetRotation(float rotation) => this.rotation = rotation;
        
}
