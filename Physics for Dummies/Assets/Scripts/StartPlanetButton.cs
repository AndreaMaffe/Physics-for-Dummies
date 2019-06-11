using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlanetButton : InteractiveObject
{
    public Material offMaterial;
    public Material onMaterial;
    public Animator animator;

    public InteractivePlanet planet;

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
                planet.Explode();
            }

            else
            {
                isOn = true;
                meshRenderer.material = onMaterial;
                planet.StartMoving();
            }
        }
    }

    public void OnPlanetCollision()
    {
        isOn = false;
        meshRenderer.material = offMaterial;
    }

    void OnDisable()
    {
        isOn = false;
        meshRenderer.material = offMaterial;
    }


}
