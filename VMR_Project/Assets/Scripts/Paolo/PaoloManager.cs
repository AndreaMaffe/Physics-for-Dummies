using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * TODO: come cambio le velocità dei cubi instanziati?
 * TODO: devo girare le piattaforme per farle arrivare uguali (e per far funzionare la fisica); prima però voglio vedere se riesco
 *       a fare l'animazione figa
 */

public class PaoloManager : MonoBehaviour
{
    public Ramp iceRamp;
    public Ramp steelRamp;
    public Ramp copperRamp;
    public Cube iceCube;
    public Cube steelCube;
    public Cube copperCube;

    private GameObject newObj;
    private GameObject iceObj;
    private GameObject steelObj;
    private GameObject copperObj;
    private Vector3 position;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        StartHelper();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            CreateDiagObject();
        PhysicsSimulation();
        SetVelocityScale(iceCube);
        SetVelocityScale(steelCube);
        SetVelocityScale(copperCube);
        SetWeightScale(iceCube);
        SetWeightScale(steelCube);
        SetWeightScale(copperCube);
    }
    /*
     * Instantiation methods
     */
    void CreateDiagObject()
    {
        if (!iceCube.GetComponent<Rigidbody>().isKinematic)
        {
            newObj = Instantiate(iceObj, position, rotation);
            newObj.SetActive(true);
            iceCube.vel.SetScale(0);

        } else if (!steelCube.GetComponent<Rigidbody>().isKinematic)
        {
            newObj = Instantiate(steelObj, position, rotation);
            newObj.SetActive(true);
            steelCube.vel.SetScale(0);

        } else if (!copperCube.GetComponent<Rigidbody>().isKinematic)
        {
            newObj = Instantiate(copperObj, position, rotation);
            newObj.SetActive(true);
            copperCube.vel.SetScale(0);
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
    void SetVelocityScale(Cube cube)
    {
        cube.vel.SetScale(cube.GetComponent<Rigidbody>().velocity.magnitude);
    }
    void SetWeightScale(Cube cube)
    {
        cube.weight.SetScale(cube.GetComponent<Rigidbody>().mass * Mathf.Sin(Mathf.PI / 4));
    }
    float DynFrictionForceComputation(double dynFrictionCohefficient, float mass, Vector3 velocity) =>
        (((float)dynFrictionCohefficient) * mass * Physics.gravity.magnitude * Mathf.Cos(Mathf.PI / 4) * velocity / velocity.magnitude).magnitude;

    /*
     * Start support method
     */
    void StartHelper()
    {
        iceObj = iceCube.gameObject;
        steelObj = steelCube.gameObject;
        copperObj = copperCube.gameObject;
        rotation = iceObj.transform.rotation;
        position = iceObj.transform.position;
        iceCube.dyn.SetScale(0);
        steelCube.dyn.SetScale(0);
        copperCube.dyn.SetScale(0);
        iceCube.vel.SetScale(0);
        steelCube.vel.SetScale(0);
        copperCube.vel.SetScale(0);
        iceCube.weight.SetScale(iceObj.GetComponent<Rigidbody>().mass * Mathf.Sin(Mathf.PI / 4));
        steelCube.weight.SetScale(steelObj.GetComponent<Rigidbody>().mass * Mathf.Sin(Mathf.PI / 4));
        copperCube.weight.SetScale(copperObj.GetComponent<Rigidbody>().mass * Mathf.Sin(Mathf.PI / 4));
    }
}
