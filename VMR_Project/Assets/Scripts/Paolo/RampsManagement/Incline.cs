using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incline : MonoBehaviour
{
    public Cube cube;

    float rotation = 50f;
    float weightRotation = 225f;
    // Start is called before the first frame update
    void Start()
    {

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
            weightRotation -= 5f;
            rotation += 5f;
            transform.rotation = Quaternion.Euler(0, 0, rotation);
            cube.WeightAngleCorrection(cube.weight, Quaternion.Euler(0, 0, weightRotation));
        }
    }
    void DecreaseRotation()
    {
        if (rotation > 35f)
        {
            weightRotation += 5f;
            rotation -= 5f;
            transform.rotation = Quaternion.Euler(0, 0, rotation);
            cube.WeightAngleCorrection(cube.weight, Quaternion.Euler(0, 0, weightRotation));
        }
    }
    public float GetRotation() => rotation;
        
}
