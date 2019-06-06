using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumSupport : MonoBehaviour
{
    public float mass;
    public float ropeLength;                                                            // This value gets normalized between 0 and 1.

    // Maximum values mass and rope length can have.
    private float maxMass = 16.0f;
    private float maxLength = 1.27f;                                                    // This value corresponds to the y scale of the rope.

    // Minimum values mass and rope length can have.
    private float minMass = 0.5f;
    private float minLength = 0.4f;                                                    // This value corresponds to the y scale of the rope.

    // Values added or removed at every user interaction.
    private float deltaMass = 0.5f;
    private float deltaLength = 0.1f;

    // These values store the pendulum's initial state.
    private Transform initialPendulumTransform;
    public GameObject pendulum;
    
    public GameObject pendulumBody;
    public GameObject rope;

    // These factors are used to empirically adjust the linear limit w.r.t. the scaling of the rope.
    private float linearLimitAdjustmentFactor1 = 9f;
    private float linearLimitAdjustmentFactor2 = 7.7f;
    //public float limitScale = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialPendulumTransform = pendulum.transform;

        mass = pendulumBody.GetComponent<Rigidbody>().mass;
        ropeLength = Normalize(rope.transform.localScale.y, maxLength, minLength);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // w -> reduce rope length.
        if (Input.GetKeyDown("w"))
        {
            if (ropeLength > 0)
            {
                Reset();
                Vector3 tempScale = rope.transform.localScale;
                tempScale.y -= deltaLength;
                rope.transform.localScale = tempScale;
                ropeLength = Normalize(rope.transform.localScale.y, maxLength, minLength);

                // Adjust pendulum body position
                SoftJointLimit jointLimit = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit;
                jointLimit.limit -= (tempScale.y / linearLimitAdjustmentFactor2);

                //limitScale = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;

                pendulumBody.GetComponent<ConfigurableJoint>().linearLimit =  jointLimit;

                //limitScale -= pendulumBody.GetComponent<ConfigurableJoint>().linearLimit.limit;



            }
        }

        // s -> increase rope length.
        else if(Input.GetKeyDown("s"))
        {
            if (ropeLength < 1)
            {
                Reset();
                Vector3 tempScale = rope.transform.localScale;
                tempScale.y += deltaLength;
                rope.transform.localScale = tempScale;
                ropeLength = Normalize(rope.transform.localScale.y, maxLength, minLength);

                // Adjust pendulum body position
                SoftJointLimit jointLimit = pendulumBody.GetComponent<ConfigurableJoint>().linearLimit;
                jointLimit.limit += (tempScale.y / linearLimitAdjustmentFactor1);

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
                Reset();
                mass += deltaMass;
                pendulumBody.GetComponent<Rigidbody>().mass = mass;
            }
        }

        // a -> decrease pendulum mass.
        else if (Input.GetKeyDown("a"))
        {
            if (mass > minMass)
            {
                Reset();
                mass -= deltaMass;
                pendulumBody.GetComponent<Rigidbody>().mass = mass;
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
            Reset();

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pendulumBody.GetComponent<Rigidbody>().AddForce(Vector3.right * 10, ForceMode.Impulse);
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

    private void Reset()
    {
        pendulumBody.GetComponent<Rigidbody>().isKinematic = true;
        rope.GetComponent<Rigidbody>().isKinematic = true;

        /*pendulumBody.transform.position = initialPendulumBodyTransform.position;
        pendulumBody.transform.rotation = initialPendulumBodyTransform.rotation;
        pendulumBody.transform.localScale = initialPendulumBodyTransform.localScale;

        rope.transform.position = initialRopeTransform.position;
        rope.transform.rotation = initialRopeTransform.rotation;
        rope.transform.localScale = initialRopeTransform.localScale;*/

        pendulum.transform.position = initialPendulumTransform.position;
        pendulum.transform.rotation = Quaternion.Euler(0,0,0);
        pendulum.transform.localScale = initialPendulumTransform.localScale;

        pendulumBody.GetComponent<Rigidbody>().isKinematic = false;
        rope.GetComponent<Rigidbody>().isKinematic = false;
    }
}
