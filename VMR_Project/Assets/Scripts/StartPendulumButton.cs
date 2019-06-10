using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPendulumButton : InteractiveObject
{
    public Material offMaterial;
    public Material onMaterial;
    public Animator animator;

    public PendulumSupport pendulum;
    public GameObject interactableButtonRope;
    public GameObject interactableButtonBody;

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
        if (focused)
        {
            animator.SetTrigger("Pressed");
            AudioManager.instance.PlaySound(SoundType.Pop);

            if (isOn)
            {
                isOn = false;
                meshRenderer.material = offMaterial;
                pendulum.Reset();
                interactableButtonBody.SetActive(true);
                interactableButtonRope.SetActive(true);

            }

            else
            {
                isOn = true;
                meshRenderer.material = onMaterial;
                pendulum.MovePendulum();
                interactableButtonBody.SetActive(false);
                interactableButtonRope.SetActive(false);
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
