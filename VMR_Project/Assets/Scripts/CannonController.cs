using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : InteractiveObject
{
    public float angularSpeed = 20f;
    public float cannonPower = 18f;
    public GameObject cannonBody;
    public Transform cannonSphere;
    public Transform shootingPoint;
    public GameObject bullet;
    public GameObject puffAnimation;

    private float angle = 0f;

    public float GetAngle()
    {
        return angle;
    }

    void MoveUp()
    {
        if (cannonBody.transform.localRotation.eulerAngles.x > 290f)
        {
            angle = 360f - cannonBody.transform.localRotation.eulerAngles.x;
        }
        else
        {
            angle = -cannonBody.transform.localRotation.eulerAngles.x;
        }
        if (angle<60f) {
            cannonBody.transform.RotateAround(cannonSphere.transform.position, Vector3.Cross(-transform.forward, transform.up), -angularSpeed);
        }
    }

    void MoveDown()
    {
        if (cannonBody.transform.localRotation.eulerAngles.x > 290f)
        {
            angle = 360f - cannonBody.transform.localRotation.eulerAngles.x;
        }
        else
        {
            angle = -cannonBody.transform.localRotation.eulerAngles.x;
        }
        if (angle>0f) {
            cannonBody.transform.RotateAround(cannonSphere.transform.position, Vector3.Cross(-transform.forward, transform.up), angularSpeed);

        }
    }

    void Fire()
    {
        GameObject puff = Instantiate(puffAnimation, shootingPoint.position, transform.rotation, transform);
        GameObject bulletObject = Instantiate(bullet, shootingPoint.position, transform.rotation, transform);
        Rigidbody bulletRb = bulletObject.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootingPoint.forward * cannonPower, ForceMode.VelocityChange);
        AudioManager.instance.PlaySound(SoundType.Boom);
    }

    public override void OnClick()
    {
        Fire();
    }

    public override void OnArrowUp()
    {
        MoveUp();
    }

    public override void OnArrowDown()
    {
        MoveDown();
    }

    private void OnDisable()
    {
        cannonBody.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        angle = 0f;
    }
}
