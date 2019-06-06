using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeButton : InteractiveObject
{
    public Material offMaterial;
    public Material onMaterial;
    public Animator animator;
    public PaoloManager manager;

    private bool isOn;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
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
            manager.getActiveCube().gameObject.SetActive(false);
            manager.CreateCube();
            manager.getActiveCube().GetComponent<Rigidbody>().isKinematic = true;
        } else
        {
            isOn = true;
            meshRenderer.material = onMaterial;
            manager.getActiveCube().GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}

