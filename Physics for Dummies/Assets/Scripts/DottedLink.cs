using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedLink : MonoBehaviour
{
    public GameObject otherGameObject;

    private void Update()
    {
        LineDrawer.Instance.DrawDottedLine(this.transform.position, otherGameObject.transform.position);
    }
}
