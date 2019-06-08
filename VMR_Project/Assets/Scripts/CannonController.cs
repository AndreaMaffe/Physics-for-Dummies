using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : InteractiveObject
{
    public float angularSpeed = 30f;
    public float cannonPower = 60f;
    public GameObject cannonBody;
    public Transform cannonSphere;
    public Transform shootingPoint;
    public GameObject bullet;
    public GameObject puffAnimation;

    void MoveUp()
    {
        if ((cannonBody.transform.localRotation.eulerAngles.x <= 360f && cannonBody.transform.localRotation.eulerAngles.x >= 300f) || (cannonBody.transform.localRotation.eulerAngles.x >= 0f && cannonBody.transform.localRotation.eulerAngles.x <= 46f)) {
            cannonBody.transform.RotateAround(cannonSphere.transform.position, Vector3.Cross(-transform.forward, transform.up), -angularSpeed * Time.deltaTime);
        }
    }

    void MoveDown()
    {
        if ((cannonBody.transform.localRotation.eulerAngles.x >= -1f && cannonBody.transform.localRotation.eulerAngles.x <= 45f) || (transform.localRotation.eulerAngles.x >= 299f && transform.localRotation.eulerAngles.x <= 360f)) {
            cannonBody.transform.RotateAround(cannonSphere.transform.position, Vector3.Cross(-transform.forward, transform.up), angularSpeed * Time.deltaTime);
        }
    }

    void Fire()
    {
        GameObject puff = Instantiate(puffAnimation, shootingPoint.position, transform.rotation);
        GameObject bulletObject = Instantiate(bullet, shootingPoint.position, transform.rotation);
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

    public override void OnBackToMainMenu()
    {
        cannonBody.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
