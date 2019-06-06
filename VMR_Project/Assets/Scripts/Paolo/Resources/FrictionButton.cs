using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionButton : InteractiveObject
{
    public Material lowMaterial;
    public Material middleMaterial;
    public Material highMaterial;
    public PhysicMaterial ice;
    public PhysicMaterial wood;
    public PhysicMaterial steel;
    public Animator animator;
    public PaoloManager manager;

    private readonly PhysicMaterial[] physicMaterials = new PhysicMaterial[3];
    private readonly Material[] materials = new Material[3];
    private int isOn;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        materials[0] = lowMaterial;
        materials[1] = middleMaterial;
        materials[2] = highMaterial;
        physicMaterials[0] = ice;
        physicMaterials[1] = wood;
        physicMaterials[2] = steel;
        meshRenderer = GetComponent<MeshRenderer>();
        isOn = 0;
        meshRenderer.material = materials[isOn];
    }

    public override void OnArrowUp()
    {
        animator.SetTrigger("Pressed");
        
        if(isOn == 2)
        {
            isOn = 0;
        } else
        {
            isOn++;
        }
        meshRenderer.material = materials[isOn];
        manager.ramp.incline.GetComponent<BoxCollider>().material = physicMaterials[isOn];
    }

    public override void OnArrowDown()
    { 
        animator.SetTrigger("Pressed");

        if (isOn == 0)
        {
            isOn = 2;
        }
        else
        {
            isOn--;
        }
        meshRenderer.material = materials[isOn];
        manager.ramp.incline.GetComponent<BoxCollider>().material = physicMaterials[isOn];
    }

    public override void OnClick()
    {
    }
}
