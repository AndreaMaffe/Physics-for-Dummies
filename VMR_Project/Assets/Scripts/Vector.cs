using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    public GameObject trail;
    public GameObject point;

    float vectorScale = 1f;

    public void SetScale(float scale)
    {
        vectorScale = scale;
        trail.transform.localScale = new Vector3(1f, vectorScale, 1f);
        float newY = trail.transform.localScale.y * 2 + point.transform.localScale.y / 2;
        point.transform.localPosition = new Vector3(0f, newY, 0f);
    }
}
