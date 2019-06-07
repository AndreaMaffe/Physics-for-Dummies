using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeButton : InteractiveObject
{
    public Material offMaterial;
    public Material onMaterial;
    public Animator animator;
    public Cube cube;
    public PaoloManager manager;
    public Incline incline;

    private bool isOn;
    private MeshRenderer meshRenderer;
    private Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = incline.GetOriginalRotation();
        meshRenderer = GetComponent<MeshRenderer>();
        isOn = false;
    }

    /*private void FixedUpdate()
    {
        if(isOn && manager.getActiveCube().GetComponent<Rigidbody>().isKinematic)
            manager.getActiveCube().GetComponent<Rigidbody>().isKinematic = false;
    }*/

    public override void OnArrowDown()
    {
    }

    public override void OnArrowUp()
    {
    }

    public override void OnClick()
    {
        animator.SetTrigger("Pressed");

        if (isOn)
        {
            isOn = false;
            meshRenderer.material = offMaterial;
            cube.CreateCube();
            cube.GetComponent<Rigidbody>().isKinematic = true;
        } else
        {
            isOn = true;
            meshRenderer.material = onMaterial;
            cube.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}

