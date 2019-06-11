using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBody : InteractiveObject
{
    public float mass;
    public float weightScale;

    // Extreme values the pendulum mass can have.
    private float minMass = 1f;
    private float maxMass = 1.3f;

    // Value added or removed at every user interaction.
    private float deltaMass = 0.025f;
    private float deltaWeightScale = 0.25f;

    public PendulumSupport pendulumSupport;
    public Vector weight;

    // Start is called before the first frame update
    void Start()
    {
        mass = this.gameObject.GetComponent<Rigidbody>().mass;
        weightScale = 2;
        weight.SetScale(weightScale);
    }

    /**
     * Used to decrease the mass.
     */
    public override void OnArrowDown()
    {
        if (pendulumSupport.GetComponent<PendulumSupport>().isPendulumReset && focused)
        {
            if (mass > minMass)
            {
                mass -= deltaMass;
                weightScale -= deltaWeightScale;
                this.gameObject.GetComponent<Rigidbody>().mass = mass;

                // Descrease the pendulum's scale.
                Vector3 newScale = this.gameObject.transform.localScale - new Vector3(0.02f, 0.02f, 0.02f);
                this.gameObject.transform.localScale = newScale;

                // Adjust the SphereCollider radius, so that it remains constant with the pendulumBody scaling.
                this.gameObject.GetComponent<SphereCollider>().radius = pendulumSupport.pendulumBodyColliderRadius / this.gameObject.transform.localScale.x;

                // Decrease weight scale.
                weight.SetScale(weightScale);
            }
        }
    }

    /**
     * Used to increase the mass.
     */
    public override void OnArrowUp()
    {
        if (pendulumSupport.GetComponent<PendulumSupport>().isPendulumReset && focused)
        {
            if (mass < maxMass)
            {
                mass += deltaMass;
                weightScale += deltaWeightScale;
                this.gameObject.GetComponent<Rigidbody>().mass = mass;

                // Increase the pendulum's scale.
                Vector3 newScale = this.gameObject.transform.localScale + new Vector3(0.02f, 0.02f, 0.02f);
                this.gameObject.transform.localScale = newScale;

                // Adjust the SphereCollider radius, so that it remains constant with the pendulumBody scaling.
                this.gameObject.GetComponent<SphereCollider>().radius = pendulumSupport.pendulumBodyColliderRadius / this.gameObject.transform.localScale.x;

                // Increase weight scale.
                weight.SetScale(weightScale);
            }
        }
    }

    public void OnDisable()
    {
        pendulumSupport.Reset();
        focused = false;
    }

    public override void OnClick()
    {
        // Not needed.
    }
}
