using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incline : InteractiveObject
{
    public Cube cube;

    float rotation = 50f;
    float weightRotation = 225f;

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
        if (rotation > 30f)
        {
            weightRotation += 5f;
            rotation -= 5f;
            transform.rotation = Quaternion.Euler(0, 0, rotation);
            cube.WeightAngleCorrection(cube.weight, Quaternion.Euler(0, 0, weightRotation));
        }
    }

    public float GetRotation() => rotation;

    public override void OnClick()
    {
    }

    public override void OnArrowUp()
    {
        if (focused)
            IncreaseRotation();
    }

    public override void OnArrowDown()
    {
        if (focused)
            DecreaseRotation();
    }
    public void OnDisable()
    {
        rotation = 50f;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
