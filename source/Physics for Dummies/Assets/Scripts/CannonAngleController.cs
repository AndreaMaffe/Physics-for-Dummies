using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAngleController : MonoBehaviour
{
    private CannonController angle;
    private TextMesh txt;

    void Start()
    {
        angle = GetComponent<CannonController>();
        txt = GetComponentInChildren<TextMesh>();
        string a = string.Format("{0:F2}", angle.GetAngle()) + "°";
        txt.text = a;
    }

    void Update()
    {
        string a = string.Format("{0:F2}", angle.GetAngle()) + "°";
        txt.text = a;
    }
}
