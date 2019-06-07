using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartThreePlanetsButton : InteractiveObject
{
    public Material offMaterial;
    public Material onMaterial;
    public Animator animator;

    public SmallPlanet planet1, planet2, planet3;

    private bool isOn;
    private MeshRenderer meshRenderer;


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
                planet1.ResetPosition();
                planet2.ResetPosition();
                planet3.ResetPosition();
            }

            else
            {
                isOn = true;
                meshRenderer.material = onMaterial;
                planet1.ApplyForce();
                planet2.ApplyForce();
                planet3.ApplyForce();
            }
        }
    }

    public void OnPlanetCollision()
    {
        isOn = false;
        meshRenderer.material = offMaterial;
    }
}
