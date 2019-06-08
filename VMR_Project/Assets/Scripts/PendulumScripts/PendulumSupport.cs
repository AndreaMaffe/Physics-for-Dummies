using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumSupport : MonoBehaviour
{
    public float mass;
    public float ropeLength;
    private float initialMass;
    private float initialRopeLength;

    // Maximum values mass and rope length can have.
    private float maxMass = 1.25f;
    private float maxLength = 1.2f;                                                    // This value corresponds to the maximum y scale of the rope.

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
    //private SoftJointLimit initialJointLimit;
    private Vector3 initialConnectedAnchor;

    // GameObjects whose parameters are needed.
    public GameObject pendulumSupport;
    public GameObject pendulumBody;
    public GameObject rope;
    public Vector weight;

    // These factors are used to empirically adjust the linear limit w.r.t. the scaling of the rope.
    private float linearLimitAdjustmentFactor1 = 9f;
    private float linearLimitAdjustmentFactor2 = 7.7f;

    // This value indicated whether the pendulum is in its initial position or not.
    public bool isPendulumReset = true;

    // This value modifies the value of the torque applied to the rope when the pendulum movement is started.
    private float appliedForceAmount = 4f;

    // Start is called before the first frame update
    void Start()
    {
        initialRopeRotation = rope.transform.rotation;
        initialRopeScale = rope.transform.localScale;

        initialPendulumBodyRotation = pendulumBody.transform.rotation;
        initialPendulumBodyPosition = pendulumBody.transform.position;
        initialPendulumBodyScale = pendulumBody.transform.localScale;
        //initialJointLimit = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit;
        initialConnectedAnchor = pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor;

        mass = pendulumBody.GetComponent<Rigidbody>().mass;
        initialMass = mass;
        ropeLength = rope.transform.localScale.y;
        initialRopeLength = ropeLength;
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
    public void Reset()
    {
        pendulumBody.GetComponent<Rigidbody>().isKinematic = true;
        rope.GetComponent<Rigidbody>().isKinematic = true;

        pendulumBody.transform.position = initialPendulumBodyPosition;
        pendulumBody.transform.rotation = initialPendulumBodyRotation;
        pendulumBody.transform.localScale = initialPendulumBodyScale;
        //pendulumBody.GetComponent<ConfigurableJoint>().linearLimit = initialJointLimit;
        pendulumBody.GetComponent<ConfigurableJoint>().connectedAnchor = initialConnectedAnchor;
        mass = initialMass;
        weight.SetScale(mass);


        rope.transform.rotation = initialRopeRotation;
        rope.transform.localScale = initialRopeScale;
        ropeLength = initialRopeLength;

        isPendulumReset = true;
    }

    /**
     * This function is used to start the movement of the pendulum.
     */
    public void MovePendulum()
    {
        isPendulumReset = false;

        pendulumBody.GetComponent<Rigidbody>().isKinematic = false;
        rope.GetComponent<Rigidbody>().isKinematic = false;

        pendulumBody.GetComponent<Rigidbody>().AddForce(Vector3.right * appliedForceAmount, ForceMode.VelocityChange);
    }
}
