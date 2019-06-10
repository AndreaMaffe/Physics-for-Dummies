using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveHeight : InteractiveObject
{
    public float ropeLength;                                                            

    // Extreme values the pendulum rope can have.
    private float maxLength = 1.0f;                                                    // This value corresponds to the maximum y scale of the rope.
    private float minLength = 0.4f;                                                    // This value corresponds to the minimum y scale of the rope.

    // Value added or removed at every user interaction.
    private float deltaLength = 0.05f;

    // Scale of the whole object, saved in a variable for performance reasons.
    private float pendulumSupportScale = 10;

    public GameObject rope;
    public GameObject pendulumBody;
    public PendulumSupport pendulumSupport;

    void Start()
    {
        ropeLength = rope.transform.localScale.y;
    }

    public override void OnArrowDown()
    {
        if (pendulumSupport.GetComponent<PendulumSupport>().isPendulumReset && focused)
        {
            if (ropeLength < maxLength)
            {
                Vector3 tempScale = rope.transform.localScale;
                tempScale.y += deltaLength;
                rope.transform.localScale = tempScale;
                ropeLength = rope.transform.localScale.y;

                // Adjust pendulum body's configurable joint connected anchor.
                Vector3 newAnchor = new Vector3(pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.x,
                    pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.y - deltaLength / pendulumSupportScale,
                    pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.z);
                pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor = newAnchor;

                // Adjust pendulum body position
                Vector3 newPosition = new Vector3(pendulumBody.transform.position.x, pendulumBody.transform.position.y - deltaLength * pendulumSupportScale,
                    pendulumBody.transform.position.z);
                pendulumBody.transform.position = newPosition;
                pendulumSupport.startingPendulumHeight = pendulumBody.transform.position.y;
            }
        }
    }

    public override void OnArrowUp()
    {
        if (pendulumSupport.GetComponent<PendulumSupport>().isPendulumReset && focused)
        {
            if (ropeLength > minLength)
            {
                Vector3 tempScale = rope.transform.localScale;
                tempScale.y -= deltaLength;
                rope.transform.localScale = tempScale;
                ropeLength = rope.transform.localScale.y;

                // Adjust pendulum body's configurable joint connected anchor.
                Vector3 newAnchor = new Vector3(pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.x,
                    pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.y + deltaLength / pendulumSupportScale,
                    pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.z);
                pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor = newAnchor;

                // Adjust pendulum body position
                Vector3 newPosition = new Vector3(pendulumBody.transform.position.x, pendulumBody.transform.position.y + deltaLength * pendulumSupportScale,
                    pendulumBody.transform.position.z);
                pendulumBody.transform.position = newPosition;
            }
        }
    }

    public void OnDisable()
    {
        pendulumSupport.Reset();
    }

    public override void OnClick()
    {
        // Not needed.
    }
}
