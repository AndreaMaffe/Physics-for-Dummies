using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaoloManager : MonoBehaviour
{
    public Ramp iceRamp;
    public Ramp steelRamp;
    public Ramp copperRamp;
    public Cube iceCube;
    public Cube steelCube;
    public Cube copperCube;

    private GameObject iceObj;
    private GameObject steelObj;
    private GameObject copperObj;
    private Vector3 icePosition;
    private Quaternion iceRotation;

    // Start is called before the first frame update
    void Start()
    { 
        iceObj = iceCube.gameObject;
        steelObj = steelCube.gameObject;
        copperObj = copperCube.gameObject;
        iceRotation = iceObj.transform.rotation;
        icePosition = iceObj.transform.position;
        iceCube.dyn.SetScale(0);
        steelCube.dyn.SetScale(0);
        copperCube.dyn.SetScale(0);
        iceCube.vel.SetScale(0);
        steelCube.vel.SetScale(0);
        copperCube.vel.SetScale(0);
        iceCube.weight.SetScale(iceObj.GetComponent<Rigidbody>().mass);
        steelCube.weight.SetScale(steelObj.GetComponent<Rigidbody>().mass);
        copperCube.weight.SetScale(copperObj.GetComponent<Rigidbody>().mass);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            CreateDiagObject();
        PhysicsSimulation();
        setVelocityScale(iceCube);
        setVelocityScale(steelCube);
        setVelocityScale(copperCube);
    }
    /*
     * Instantiation methods
     */
    void CreateDiagObject()
    {
        if (iceObj.activeSelf)
        {
            Instantiate(iceObj, icePosition, iceRotation);
        }
        else
        {
            iceObj.SetActive(true);
        }
    }

    /*
     * Physics simulation
     */
    void PhysicsSimulation()
    {
        if (!this.steelObj.GetComponent<Rigidbody>().isKinematic)
        {
            float dynForce1 = DynFrictionForceComputation(0.3, steelCube.GetComponent<Rigidbody>().mass,
                steelCube.GetComponent<Rigidbody>().velocity);
            steelCube.dyn.SetScale(dynForce1);
            //Debug.Log("Steel dynamic force: " + dynForce1);
        }
        if (!this.copperObj.GetComponent<Rigidbody>().isKinematic)
        {
            float dynForce2 = DynFrictionForceComputation(0.18, copperCube.GetComponent<Rigidbody>().mass,
                copperCube.GetComponent<Rigidbody>().velocity);
            copperCube.dyn.SetScale(dynForce2);
            //Debug.Log("Copper dynamic force: " + dynForce2);
        }
    }
    void setVelocityScale(Cube cube)
    {
        cube.vel.SetScale(cube.GetComponent<Rigidbody>().velocity.magnitude);
    }
    float DynFrictionForceComputation(double dynFrictionCohefficient, float mass, Vector3 velocity) =>
        (((float)dynFrictionCohefficient) * mass * Physics.gravity.magnitude * Mathf.Cos(Mathf.PI / 4) * velocity / velocity.magnitude).magnitude;
}
