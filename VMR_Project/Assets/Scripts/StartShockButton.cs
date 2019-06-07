using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShockButton : InteractiveObject
{

    public Material offMaterial;
    public Material onMaterial;
    public Animator animator;

    private bool isOn;
    private MeshRenderer meshRenderer;
    public ShockSphere shockSphere1;
    public ShockSphere shockSphere2;

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

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
            OnClick();
            
    }

    public override void OnClick()
    {
        //if (focused)
        {
            animator.SetTrigger("Pressed");
            AudioManager.instance.PlaySound(SoundType.Pop);

            if (isOn)
            {
                isOn = false;
                meshRenderer.material = offMaterial;
                shockSphere1.ResetPosition();
                shockSphere2.ResetPosition();
            }

            else
            {
                isOn = true;
                meshRenderer.material = onMaterial;
                shockSphere1.StartAddForce();
            }
        }
    }
}
