using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionButton : InteractiveObject
{
    public PhysicMaterial ice;
    public PhysicMaterial wood;
    public PhysicMaterial steel;
    public Animator animator;
    public Incline incline;
    public FrictionBar frictionBar;

    private readonly PhysicMaterial[] physicMaterials = new PhysicMaterial[3];
    private int isOn;

    // Start is called before the first frame update
    void Start()
    {
        physicMaterials[0] = ice;
        physicMaterials[1] = wood;
        physicMaterials[2] = steel;
        isOn = 0;
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
        incline.GetComponent<BoxCollider>().material = physicMaterials[isOn];

        frictionBar.ChangeBarLength(true, false);
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
        incline.GetComponent<BoxCollider>().material = physicMaterials[isOn];

        frictionBar.ChangeBarLength(false, true);
    }

    public override void OnClick()
    {
    }
}
