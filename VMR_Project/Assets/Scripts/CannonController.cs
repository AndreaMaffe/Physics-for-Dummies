using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float angularSpeed = 20f;
    public float cannonPower = 60f;
    public Transform cannonSphere;
    public Transform shootingPoint;
    public GameObject bullet;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void MoveUp()
    {
        //if ((transform.localRotation.eulerAngles.x <= 360f && transform.localRotation.eulerAngles.x >= 300f) || (transform.localRotation.eulerAngles.x >= 0f && transform.localRotation.eulerAngles.x <= 46f)) {
            transform.RotateAround(cannonSphere.transform.position, Vector3.right, -angularSpeed * Time.deltaTime);
        //}
    }

    void MoveDown()
    {
        //if ((transform.localRotation.eulerAngles.x >= -1f && transform.localRotation.eulerAngles.x <= 45f) || (transform.localRotation.eulerAngles.x >= 299f && transform.localRotation.eulerAngles.x <= 360f)) {
            transform.RotateAround(cannonSphere.transform.position, Vector3.right, angularSpeed * Time.deltaTime);
        //}
    }

    void Fire()
    {
        GameObject bulletObject = Instantiate(bullet, shootingPoint.position, new Quaternion(0f, 0f, 0f, 0f));
        Rigidbody bulletRb = bulletObject.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootingPoint.forward * cannonPower, ForceMode.VelocityChange);
    }
}
