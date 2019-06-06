using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : InteractiveObject
{
    public float angularSpeed = 20f;
    public float cannonPower = 60f;
    public Transform cannonSphere;
    public Transform shootingPoint;
    public GameObject bullet;

    private bool focused;

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


}
