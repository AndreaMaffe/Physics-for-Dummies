using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * TODO: mettere il bottone per cambiare runtime il coefficiente di attrito (da fare tramite la classe StartBotton)
 */

public class PaoloManager : MonoBehaviour
{
    public Ramp ramp;
    public Cube cube;

    private GameObject newObj;
    private GameObject cubeObj;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private float startMass;
    private float dynFrictionForce;

    // Start is called before the first frame update
    void Start()
    {
        cubeObj = cube.gameObject;
        startRotation = cubeObj.transform.rotation;
        startPosition = cubeObj.transform.position;
        startMass = cube.GetComponent<Rigidbody>().mass;
        cube.dyn.SetScale(0);
        cube.vel.SetScale(0);
        cube.tanWeight.SetScale(cubeObj.GetComponent<Rigidbody>().mass * Mathf.Sin(Mathf.PI / 4));
        cube.weight.SetScale(cubeObj.GetComponent<Rigidbody>().mass);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            CreateCube();
        if(newObj == null)
        {
            dynFrictionForce = cube.DynFrictionForceComputation(ramp.incline.GetComponent<BoxCollider>().material.dynamicFriction, cube.GetComponent<Rigidbody>().mass,
               cube.GetComponent<Rigidbody>().velocity);
            cube.DynSetScale(dynFrictionForce);
        } else
        {
            dynFrictionForce = newObj.GetComponent<Cube>().DynFrictionForceComputation(ramp.incline.GetComponent<BoxCollider>().material.dynamicFriction, newObj.GetComponent<Cube>().GetComponent<Rigidbody>().mass,
               newObj.GetComponent<Cube>().GetComponent<Rigidbody>().velocity);
            newObj.GetComponent<Cube>().DynSetScale(dynFrictionForce);
        }
           
    }
    /*
     * Instantiation methods
     */
    void CreateCube()
    {
        cube.vel.SetScale(0);
        newObj = Instantiate(cubeObj, startPosition, startRotation);
        newObj.SetActive(true);
        newObj.GetComponent<Cube>().GetComponent<Rigidbody>().mass = startMass;
    }

    public Cube getActiveCube()
    {
        if(newObj)
        {
            return newObj.GetComponent<Cube>();
        } else
        {
            return cube;
        }
    }
    public float getFrictionForce() => dynFrictionForce;
}
