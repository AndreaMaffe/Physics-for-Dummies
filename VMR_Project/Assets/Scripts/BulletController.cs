using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject velocity;
    public GameObject velocityX;
    public GameObject velocityY;
    public GameObject gravity;
    public GameObject puffAnimation;

    private float factorScale = 0.15f;
    private Vector3 lastFramePosition;
    private Vector3 initialPosition;
    private Vector velocityArrowScript;
    private Vector velocityXArrowScript;
    private Vector velocityYArrowScript;

    void Start() {
        gravity.GetComponent<Vector>().SetScale(9.81f * factorScale);
        velocityArrowScript = velocity.GetComponent<Vector>();
        velocityXArrowScript = velocityX.GetComponent<Vector>();
        velocityYArrowScript = velocityY.GetComponent<Vector>();
        lastFramePosition = transform.position;
        initialPosition = transform.position;
    }
    
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 linearVelocity = transform.position - lastFramePosition;
        Vector3 newRotation = Quaternion.LookRotation(linearVelocity).eulerAngles + Quaternion.Euler(90f, 0f, 0f).eulerAngles;
        float alphaRad = (newRotation.x - 90) * Mathf.PI / 180;
        Vector3 newPosition = new Vector3(0f, -Mathf.Sin(alphaRad), Mathf.Cos(alphaRad));
        float vel = rb.velocity.magnitude;
        bool isDescending = -Mathf.Sin(alphaRad) < 0;

        velocity.transform.rotation = Quaternion.Euler(newRotation);
        velocityArrowScript.SetScale(vel * factorScale);
        velocityXArrowScript.SetScale(vel * Mathf.Cos(alphaRad) * factorScale);
        velocityY.transform.localRotation = Quaternion.Euler(!isDescending ? 0f : 180f, 0f, 0f);
        velocityYArrowScript.SetScale(vel * Mathf.Abs(-Mathf.Sin(alphaRad)) * factorScale);
        //gravity.transform.rotation = Quaternion.Euler(180, 0, 0);

        lastFramePosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GameObject puff = Instantiate(puffAnimation, transform.position, transform.rotation, transform);
            AudioManager.instance.PlaySound(SoundType.Boom);
            bullet.SetActive(false);
            velocity.SetActive(false);
            velocityX.SetActive(false);
            velocityY.SetActive(false);
            gravity.SetActive(false);
            StartCoroutine("DestroyCannonBall");
        }
    }

    IEnumerator DestroyCannonBall()
    {
        TrailRenderer trail = GetComponent<TrailRenderer>();
        yield return new WaitUntil(() => trail.positionCount==0);
        Destroy(gameObject);
        yield return null;
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

}
