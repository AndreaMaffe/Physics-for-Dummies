using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incline : InteractiveObject
{
    public Cube cube;
    public GameObject interactiveObject;

    float rotation = 55f;
    float weightRotation = 220f;

    void IncreaseRotation()
    {
        if(rotation < 75f)
        {
            weightRotation -= 1f;
            rotation += 1f;
            transform.rotation = Quaternion.Euler(0, 0, rotation);
            cube.WeightAngleCorrection(cube.weight, Quaternion.Euler(0, 0, weightRotation));
        }
    }
    void DecreaseRotation()
    {
        if (rotation > 37f)
        {
            weightRotation += 1f;
            rotation -= 1f;
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
        rotation = 55f;
        weightRotation = 220f;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        cube.WeightAngleCorrection(cube.weight, Quaternion.Euler(0, 0, weightRotation));
        interactiveObject.SetActive(true);
        focused = false;
    }
}
