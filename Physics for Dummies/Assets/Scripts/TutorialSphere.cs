using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSphere : InteractiveObject
{
    private float scale;

    private void Start()
    {
        scale = 1;
    }

    public override void OnArrowDown()
    {
        if (focused)
        {
            scale -= 0.1f;

            if (scale < 0.6f)
                scale = 0.6f;

            this.transform.localScale = new Vector3(scale, scale, scale);
        }

    }

    public override void OnArrowUp()
    {
        if (focused)
        {
            scale += 0.1f;

            if (scale > 1.4f)
                scale = 1.4f;

            this.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public override void OnClick()
    {
    }

    private void OnDisable()
    {
        scale = 1f;
        this.transform.localScale = Vector3.one;
    }
}
