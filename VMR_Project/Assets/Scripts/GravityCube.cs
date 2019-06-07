using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCube : MonoBehaviour
{
    public GameObject potentialEnergyBar;
    public GameObject kyneticEnergyBar;
    public GameObject cube;
    public GameObject bottom;

    private Rigidbody rb;
    private float mass;
    private Vector3 maxBarSize;
    private float maxEnergy;
    private Vector3 ground;

    void Start()
    {
        RaycastHit hit;
        Physics.Raycast(bottom.transform.position, Vector3.down, out hit);
        ground = hit.point;

        rb = cube.GetComponent<Rigidbody>();
        mass = rb.mass;
        maxBarSize = potentialEnergyBar.transform.localScale;

        float gravity = Physics.gravity.magnitude;
        float h = Vector3.Distance(bottom.transform.position, ground);
        maxEnergy = 8*rb.mass*gravity;
    }

    void Update()
    {
        float velocity = rb.velocity.magnitude;
        float kyneticEnergy = mass * velocity * velocity / 2;

        float gravity = Physics.gravity.magnitude;
        float h = Vector3.Distance(bottom.transform.position, ground);
        float potentialEnergy = mass * gravity * h;

        float potentialBarLenght = maxBarSize.x * (potentialEnergy / maxEnergy);
        if (potentialBarLenght > maxBarSize.x)
            potentialBarLenght = maxBarSize.x;
        float kyneticBarLenght = maxBarSize.x * (kyneticEnergy / maxEnergy);

        potentialEnergyBar.transform.localScale = new Vector3(potentialBarLenght, maxBarSize.y, maxBarSize.z);
        kyneticEnergyBar.transform.localScale = new Vector3(kyneticBarLenght, maxBarSize.y, maxBarSize.z);

        LineDrawer.Instance.DrawDottedLine(bottom.transform.position, ground);

        if (cube.transform.position.y < 0.5f)
        {
            cube.transform.position = new Vector3(cube.transform.position.x, 0.5f, cube.transform.position.z);
        }

    }
}
