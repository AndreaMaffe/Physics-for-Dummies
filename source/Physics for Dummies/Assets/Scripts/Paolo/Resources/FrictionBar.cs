using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionBar : MonoBehaviour
{
    public GameObject frictionBar;
    public Material ice;
    public Material copper;
    public Material wood;
    public Material steel;

    private float maxBarSize;
    private float actualSize;
    private float sizeToIncrement;
    private Material[] materials = new Material[4];
    private int index;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = frictionBar.GetComponentInChildren<MeshRenderer>();
        maxBarSize = frictionBar.transform.localScale.x;
        actualSize = 0;
        sizeToIncrement = maxBarSize / 3;
        materials[0] = ice;
        materials[1] = copper;
        materials[2] = wood;
        materials[3] = steel;
        meshRenderer.material = ice;
        index = 0;
        frictionBar.SetActive(false);
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
            if (index == 3)
            {
                index = 0;
                actualSize = 0;
                frictionBar.SetActive(false);
            }
            else
            {
                if (!frictionBar.activeSelf)
                    frictionBar.SetActive(true);
                index++;
                actualSize += sizeToIncrement;
            }       
        }
        if (decrease)
        {
            if (index == 0)
            {
                frictionBar.SetActive(true);
                index = 3;
                actualSize = maxBarSize;
            }
            else
            {
                index--;
                actualSize -= sizeToIncrement;
                if (index == 0)
                    frictionBar.SetActive(false);
            }
        }
        meshRenderer.material = materials[index];
    }

    public void Reset()
    {
        actualSize = 0;
        index = 0;
        frictionBar.SetActive(false);
        meshRenderer.material = materials[index];
    }
}
