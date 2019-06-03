using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    public GameObject potentialEnergyBar;
    public GameObject kyneticEnergyBar;

    private Rigidbody rb;
    private float mass;
    private Vector3 maxBarSize;
    private float initialEnergy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
        maxBarSize = potentialEnergyBar.transform.localScale;

        float gravity = Physics.gravity.magnitude;
        float h = this.transform.position.y;
        initialEnergy = mass * gravity * h;

        Debug.Log("Initial Energy = " + initialEnergy);
    }

    void Update()
    {
        float velocity = rb.velocity.magnitude;
        float kyneticEnergy = mass * velocity * velocity / 2;

        float gravity = Physics.gravity.magnitude;
        float h = this.transform.position.y;
        float potentialEnergy = mass * gravity * h;

        float potentialBarLenght = maxBarSize.x * (potentialEnergy / initialEnergy);
        float kyneticBarLenght = maxBarSize.x * (kyneticEnergy / initialEnergy);

        potentialEnergyBar.transform.localScale = new Vector3(potentialBarLenght, maxBarSize.y, maxBarSize.z);
        kyneticEnergyBar.transform.localScale = new Vector3(kyneticBarLenght, maxBarSize.y, maxBarSize.z);

        Debug.Log("Kynetic Energy = " + kyneticEnergy + " - Potential Energy = " + potentialEnergy);

    }
}
