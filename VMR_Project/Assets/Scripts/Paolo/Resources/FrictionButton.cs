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
    public GameObject forceBar;
    public GameObject frictionBar;

    private PhysicMaterial[] physicMaterials = new PhysicMaterial[3];
    private Material[] materials = new Material[3];
    private int isOn;
    private MeshRenderer meshRenderer;
    private Vector3 maxBarSize;
    private float frictionForce;
    private float maxForce;
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
        frictionForce = manager.getFrictionForce();
        maxForce = 8 * Physics.gravity.magnitude * manager.getActiveCube().GetMass();
        maxBarSize = forceBar.transform.localScale;
        forceBar.transform.localScale = new Vector3(0, maxBarSize.y, maxBarSize.z);
        frictionBar.transform.localScale = new Vector3(0, maxBarSize.y, maxBarSize.z);
    }

    private void FixedUpdate()
    {
        frictionForce = manager.getFrictionForce();
        float frictionForceBarLenght = maxBarSize.x * (frictionForce / maxForce);
        if (frictionForceBarLenght > maxBarSize.x)
            frictionForceBarLenght = maxBarSize.x;

        forceBar.transform.localScale = new Vector3(frictionForceBarLenght, maxBarSize.y, maxBarSize.z);
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
        frictionBar.transform.localScale = new Vector3(maxBarSize.x * (isOn / 2), maxBarSize.y, maxBarSize.z);
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
        frictionBar.transform.localScale = new Vector3(maxBarSize.x * (isOn / 2), maxBarSize.y, maxBarSize.z);
    }

    public override void OnClick()
    {
    }
}
