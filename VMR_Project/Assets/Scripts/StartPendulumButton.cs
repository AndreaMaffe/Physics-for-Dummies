using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPendulumButton : InteractiveObject
{
    public Material offMaterial;
    public Material onMaterial;
    public Animator animator;

    public PendulumSupport pendulum;

    private bool isOn;
    private MeshRenderer meshRenderer;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        isOn = false;
    }

    public override void OnArrowDown()
    {
        // Not needed.
    }

    public override void OnArrowUp()
    {
        // Not needed.
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
                pendulum.Reset();
            }

            else
            {
                isOn = true;
                meshRenderer.material = onMaterial;
                pendulum.MovePendulum();
            }
        }
    }

    public void OnPlanetCollision()
    {
        isOn = false;
        meshRenderer.material = offMaterial;
    }


}
