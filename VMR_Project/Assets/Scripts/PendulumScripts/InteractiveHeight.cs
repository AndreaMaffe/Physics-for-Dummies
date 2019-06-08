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
    private float deltaLength = 0.1f;

    // Scale of the whole object, saved in a variable for performance reasons.
    private float pendulumSupportScale = 10;

    // These factors are used to empirically adjust the linear limit w.r.t. the scaling of the rope.
    //private float linearLimitAdjustmentFactor1 = 9f;
    //private float linearLimitAdjustmentFactor2 = 7.7f;

    public GameObject rope;
    public GameObject pendulumBody;
    public GameObject pendulumSupport;

    public override void OnArrowDown()
    {
        if (pendulumSupport.GetComponent<PendulumSupport>().isPendulumReset)
        {
            if (ropeLength < maxLength)
            {
                Vector3 tempScale = rope.transform.localScale;
                tempScale.y += deltaLength;
                rope.transform.localScale = tempScale;
                ropeLength = rope.transform.localScale.y;

                // Adjust pendulum body position
                Vector3 newPosition = new Vector3(pendulumBody.transform.position.x, pendulumBody.transform.position.y - deltaLength * pendulumSupportScale,
                    pendulumBody.transform.position.z);
                pendulumBody.transform.position = newPosition;

                // Adjust pendulum body's configurable joint linear limit.
                /*SoftJointLimit jointLimit = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit;
                jointLimit.limit += (tempScale.y * pendulumSupportScale / linearLimitAdjustmentFactor1);
                pendulumBody.GetComponent<ConfigurableJoint>().linearLimit = jointLimit;*/

                // Adjust pendulum body's configurable joint connected anchor.
                Vector3 newAnchor = new Vector3(pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.x,
                    pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.y - deltaLength / pendulumSupportScale,
                    pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.z);
                pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor = newAnchor;

                //limitScale = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;
                //limitScale -= pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;
            }
        }
    }

    public override void OnArrowUp()
    {
        if (pendulumSupport.GetComponent<PendulumSupport>().isPendulumReset)
        {
            if (ropeLength > minLength)
            {
                Vector3 tempScale = rope.transform.localScale;
                tempScale.y -= deltaLength;
                rope.transform.localScale = tempScale;
                ropeLength = rope.transform.localScale.y;

                // Adjust pendulum body position
                Vector3 newPosition = new Vector3(pendulumBody.transform.position.x, pendulumBody.transform.position.y + deltaLength * pendulumSupportScale,
                    pendulumBody.transform.position.z);
                pendulumBody.transform.position = newPosition;

                // Adjust pendulum body's configurable joint linear limit.
                /*SoftJointLimit jointLimit = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit;
                jointLimit.limit -= (tempScale.y * pendulumSupportScale / linearLimitAdjustmentFactor2);
                pendulumBody.GetComponent<ConfigurableJoint>().linearLimit = jointLimit;*/

                // Adjust pendulum body's configurable joint connected anchor.
                Vector3 newAnchor = new Vector3(pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.x,
                    pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.y + deltaLength / pendulumSupportScale,
                    pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor.z);
                pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor = newAnchor;

                //limitScale = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;
                //limitScale -= pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;
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
        ropeLength = rope.transform.localScale.y;
    }
}
