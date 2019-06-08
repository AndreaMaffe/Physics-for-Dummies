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
    private float deltaMass = 0.05f;
    private float deltaWeightScale = 0.5f;

    public GameObject pendulumSupport;
    public Vector weight;

    public override void OnArrowDown()
    {
        if (pendulumSupport.GetComponent<PendulumSupport>().isPendulumReset)
        {
            if (mass > minMass)
            {
                mass -= deltaMass;
                weightScale -= deltaWeightScale;
                this.gameObject.GetComponent<Rigidbody>().mass = mass;

                // Descrease the pendulum's scale.
                Vector3 newScale = this.gameObject.transform.localScale - new Vector3(0.03f, 0.03f, 0.03f);
                this.gameObject.transform.localScale = newScale;

                // Decrease weight scale.
                weight.SetScale(weightScale);

                //todo adjust collider
            }
        }
    }

    public override void OnArrowUp()
    {
        if (pendulumSupport.GetComponent<PendulumSupport>().isPendulumReset)
        {
            if (mass < maxMass)
            {
                mass += deltaMass;
                weightScale += deltaWeightScale;
                this.gameObject.GetComponent<Rigidbody>().mass = mass;

                // Increase the pendulum's scale.
                Vector3 newScale = this.gameObject.transform.localScale + new Vector3(0.03f, 0.03f, 0.03f);
                this.gameObject.transform.localScale = newScale;

                // Increase weight scale.
                weight.SetScale(weightScale);

                //todo adjust collider
            }
        }
    }

    public override void OnClick()
    {
        // Not needed.
    }

    // Start is called before the first frame update
    void Start()
    {
        mass = this.gameObject.GetComponent<Rigidbody>().mass;
        weightScale = 2;
        weight.SetScale(weightScale);
    }
}
