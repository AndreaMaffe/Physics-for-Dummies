using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionBar : MonoBehaviour
{
    public GameObject frictionBar;
    public Material ice;
    public Material wood;
    public Material steel;

    private float maxBarSize;
    private float actualSize;
    private float sizeToIncrement;
    private Material[] materials = new Material[3];
    private int index;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = frictionBar.GetComponentInChildren<MeshRenderer>();
        maxBarSize = frictionBar.transform.localScale.x;
        actualSize = maxBarSize / 3;
        sizeToIncrement = maxBarSize / 3;
        materials[0] = ice;
        materials[1] = wood;
        materials[2] = steel;
        meshRenderer.material = ice;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frictionBar.transform.localScale = new Vector3(actualSize, frictionBar.transform.localScale.y, frictionBar.transform.localScale.z);
    }

    //Change size and color of the friction bar
    public void ChangeBarColorLength(bool increase, bool decrease)
    {
        if (increase)
        {
            if (index == 2)
            {
                index = 0;
                actualSize = sizeToIncrement;
            }
            else
            {
                index++;
                actualSize += sizeToIncrement;
            }       
        }
        if (decrease)
        {
            if (index == 0)
            { 
                index = 2;
                actualSize = maxBarSize;
            }
            else
            {
                index--;
                actualSize -= sizeToIncrement;
            }
        }
        meshRenderer.material = materials[index];
    }
}
