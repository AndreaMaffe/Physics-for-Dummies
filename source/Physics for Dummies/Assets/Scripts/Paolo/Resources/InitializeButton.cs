﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeButton : InteractiveObject
{
    public Material offMaterial;
    public Material onMaterial;
    public Animator animator;
    public Cube cube;
    public Incline incline;

    private bool isOn;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    { 
        meshRenderer = GetComponent<MeshRenderer>();
        isOn = false;
    }

    public override void OnArrowDown()
    {

    }

    public override void OnArrowUp()
    {
    }

    public override void OnClick()
    {
        if (focused)
        {
            animator.SetTrigger("Pressed");
            AudioManager.instance.PlaySound(SoundType.Pop);

            if (isOn)
            {
                isOn = false;
                meshRenderer.material = offMaterial;
                cube.GetComponent<Rigidbody>().isKinematic = true;
                cube.ReturnToInitialPosition();
                cube.interactableObject.SetActive(true);
                incline.interactiveObject.SetActive(true);
            }
            else
            {
                isOn = true;
                meshRenderer.material = onMaterial;
                cube.GetComponent<Rigidbody>().isKinematic = false;
                cube.interactableObject.SetActive(false);
                incline.interactiveObject.SetActive(false);
            }
        }
    }
    public void OnDisable()
    {
        isOn = false;
        meshRenderer.material = offMaterial;
        focused = false;
    }
    public void SetOff()
    {
        isOn = false;
        isOn = false;
        meshRenderer.material = offMaterial;
        cube.GetComponent<Rigidbody>().isKinematic = true;
        cube.interactableObject.SetActive(true);
        incline.interactiveObject.SetActive(true);
    }
}

