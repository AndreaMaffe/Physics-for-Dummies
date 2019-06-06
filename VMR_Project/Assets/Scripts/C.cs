using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* ------------------------------------------------------------------------------------------------

    FEDERICO:
    Ho aggiunto questo script perchè nella mia scena il cannone ruotava ma lo faceva anche la base 
    (quella marrone per intenderci).
    Non ho voluto toccare lo script che usi per evitare conflitti o cose inaspettate.
    Qui ho aggiunto il gameobject del cannone stesso e ho modificato alcune righe cosi da evitare il problema.
    Domani in caso ti spiego meglio cosa intendo e poi vedi tu cosa fare.
     
--------------------------------------------------------------------------------------------------*/

public class C : InteractiveObject
{
    public float angularSpeed = 20f;
    public float cannonPower = 60f;
    public GameObject cannonBody;
    public Transform cannonSphere;
    public Transform shootingPoint;
    public GameObject bullet;

    void MoveUp()
    {
        //if ((transform.localRotation.eulerAngles.x <= 360f && transform.localRotation.eulerAngles.x >= 300f) || (transform.localRotation.eulerAngles.x >= 0f && transform.localRotation.eulerAngles.x <= 46f)) {
        cannonBody.transform.RotateAround(cannonSphere.transform.position, Vector3.Cross(-transform.forward, transform.up), -angularSpeed * Time.deltaTime);
        //}
    }

    void MoveDown()
    {
        //if ((transform.localRotation.eulerAngles.x >= -1f && transform.localRotation.eulerAngles.x <= 45f) || (transform.localRotation.eulerAngles.x >= 299f && transform.localRotation.eulerAngles.x <= 360f)) {
        cannonBody.transform.RotateAround(cannonSphere.transform.position, Vector3.Cross(-transform.forward, transform.up), angularSpeed * Time.deltaTime);
        //}
    }

    void Fire()
    {
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
}
