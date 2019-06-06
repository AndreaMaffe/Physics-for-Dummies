using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : InteractiveObject
{
    public Material offMaterial;
    public Material onMaterial;
    public Animator animator;

    private bool isOn;
    private MeshRenderer meshRenderer;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        isOn = false;
    }

    protected override void OnArrowDown()
    {
    }

    protected override void OnArrowUp()
    {
    }

    protected override void OnClick()
    {
        animator.SetTrigger("Pressed");

        if (isOn)
        {
            isOn = false;
            meshRenderer.material = offMaterial;
        }

        else
        {
            isOn = true;
            meshRenderer.material = onMaterial;
        }
    }


}
