using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumSupport : MonoBehaviour
{
    public float mass;
    public float ropeLength;                                                            // This value gets normalized between 0 and 1.

    // Maximum values mass and rope length can have.
    private float maxMass = 1.25f;
    private float maxLength = 1.27f;                                                    // This value corresponds to the maximum y scale of the rope.

    // Minimum values mass and rope length can have.
    private float minMass = 1f;
    private float minLength = 0.4f;                                                    // This value corresponds to the minimum y scale of the rope.

    // Values added or removed at every user interaction.
    private float deltaMass = 0.05f;
    private float deltaLength = 0.1f;

    // These values store the pendulum's initial state.
    private Quaternion initialRopeRotation;
    private Vector3 initialRopeScale;
    private Quaternion initialPendulumBodyRotation;
    private Vector3 initialPendulumBodyPosition;
    private Vector3 initialPendulumBodyScale;
    private SoftJointLimit initialJointLimit;

    // GameObjects whose parameter are needed.
    public GameObject pendulumSupport;
    public GameObject pendulumBody;
    public GameObject rope;

    // These factors are used to empirically adjust the linear limit w.r.t. the scaling of the rope.
    private float linearLimitAdjustmentFactor1 = 9f;
    private float linearLimitAdjustmentFactor2 = 7.7f;

    // This value indicated whether the pendulum is in its initial position or not.
    private bool isPendulumReset = true;

    // This value modifies the value of the torque applied to the rope when the pendulum movement is started.
    private float torqueAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        initialRopeRotation = rope.transform.rotation;
        initialRopeScale = rope.transform.localScale;

        initialPendulumBodyRotation = pendulumBody.transform.rotation;
        initialPendulumBodyPosition = pendulumBody.transform.position;
        initialPendulumBodyScale = pendulumBody.transform.localScale;
        initialJointLimit = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit;

        mass = pendulumBody.GetComponent<Rigidbody>().mass;
        ropeLength = Normalize(rope.transform.localScale.y, maxLength, minLength);
    }

    // Update is called once per frame
    void Update()
    {

        // w -> reduce rope length.
        if (isPendulumReset)
        {
            if (Input.GetKeyDown("w"))
            {
                if (ropeLength > 0)
                {
                    Vector3 tempScale = rope.transform.localScale;
                    tempScale.y -= deltaLength;
                    rope.transform.localScale = tempScale;
                    ropeLength = Normalize(rope.transform.localScale.y, maxLength, minLength);

                    // Adjust pendulum body position
                    Vector3 newPosition = new Vector3(pendulumBody.transform.position.x, pendulumBody.transform.position.y + deltaLength * pendulumSupport.transform.localScale.x, 
                        pendulumBody.transform.position.z);
                    pendulumBody.transform.position = newPosition;

                    SoftJointLimit jointLimit = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit;
                    jointLimit.limit -= (tempScale.y * pendulumSupport.transform.localScale.x / linearLimitAdjustmentFactor2);

                    //limitScale = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;

                    pendulumBody.GetComponent<ConfigurableJoint>().linearLimit = jointLimit;

                    //limitScale -= pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;
                }
            }

            // s -> increase rope length.
            else if (Input.GetKeyDown("s"))
            {
                if (ropeLength < 1)
                {
                    Vector3 tempScale = rope.transform.localScale;
                    tempScale.y += deltaLength;
                    rope.transform.localScale = tempScale;
                    ropeLength = Normalize(rope.transform.localScale.y, maxLength, minLength);

                    // Adjust pendulum body position
                    Vector3 newPosition = new Vector3(pendulumBody.transform.position.x, pendulumBody.transform.position.y - deltaLength * pendulumSupport.transform.localScale.x,
                        pendulumBody.transform.position.z);
                    pendulumBody.transform.position = newPosition;

                    SoftJointLimit jointLimit = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit;
                    jointLimit.limit += (tempScale.y * pendulumSupport.transform.localScale.x / linearLimitAdjustmentFactor1);

                    //limitScale = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;

                    pendulumBody.GetComponent<ConfigurableJoint>().linearLimit = jointLimit;

                    //limitScale -= pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;
                }
            }

            // d -> increase pendulum mass.
            else if (Input.GetKeyDown("d"))
            {
                if (mass < maxMass)
                {
                    mass += deltaMass;
                    pendulumBody.GetComponent<Rigidbody>().mass = mass;

                    // Increase the pendulum's scale.
                    Vector3 newScale = pendulumBody.transform.localScale + new Vector3(0.015f, 0.015f, 0.015f);
                    pendulumBody.transform.localScale = newScale;
                }
            }

            // a -> decrease pendulum mass.
            else if (Input.GetKeyDown("a"))
            {
                if (mass > minMass)
                {
                    mass -= deltaMass;
                    pendulumBody.GetComponent<Rigidbody>().mass = mass;

                    // Descrease the pendulum's scale.
                    Vector3 newScale = pendulumBody.transform.localScale - new Vector3(0.015f, 0.015f, 0.015f);
                    pendulumBody.transform.localScale = newScale;
                }
            }


            if (Input.GetKeyDown(KeyCode.R))
            {
                MovePendulum();
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Reset();
        }
    }

    /**
     * This function normalizes the length of the rope between 0 and 1 using the standard normalization formula.
     */
    float Normalize(float valueToNormalize, float maxValue, float minValue)
    {
        double normalizedLength = (valueToNormalize - minValue) / (maxValue - minValue);
        return (float) normalizedLength;
    }

    /**
     * This function brings back the value in input to its non-normalized state.
     */
    float DeNormalize(float valueToDeNormalize, float maxValue, float minValue)
    {
        double originalValue = valueToDeNormalize * (maxValue - minValue) + minValue;
        return (float) originalValue;
    }

    /**
     * This function brings back the pendulum to its initial state.
     */
    private void Reset()
    {
        pendulumBody.GetComponent<Rigidbody>().isKinematic = true;
        rope.GetComponent<Rigidbody>().isKinematic = true;

        pendulumBody.transform.position = initialPendulumBodyPosition;
        pendulumBody.transform.rotation = initialPendulumBodyRotation;
        pendulumBody.transform.localScale = initialPendulumBodyScale;
        pendulumBody.GetComponent<ConfigurableJoint>().linearLimit = initialJointLimit;
        mass = minMass;

        rope.transform.rotation = initialRopeRotation;
        rope.transform.localScale = initialRopeScale;
        ropeLength = minLength;

        isPendulumReset = true;
    }

    /**
     * This function is used to start the movement of the pendulum.
     */
    private void MovePendulum()
    {
        isPendulumReset = false;

        pendulumBody.GetComponent<Rigidbody>().isKinematic = false;
        rope.GetComponent<Rigidbody>().isKinematic = false;

        rope.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, 1 * torqueAmount), ForceMode.VelocityChange);
    }
}
