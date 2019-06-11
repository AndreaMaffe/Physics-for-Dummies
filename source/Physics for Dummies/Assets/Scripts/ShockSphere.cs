using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockSphere : InteractiveObject
{
    private Rigidbody rb;
    private float scale;
    private GameObject sphere;
    public Transform otherSphere;
    public GameObject interactiveObjectButton;

    private Vector3 originalPosition;
    public Vector vector;

    public bool isMoving { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        scale = 1f;
        Vector3 direction = otherSphere.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(direction);
        sphere = transform.Find("Sphere").gameObject;
        isMoving = false;
    }

    private void FixedUpdate()
    {
        Vector3 newRotation = Quaternion.LookRotation(rb.velocity).eulerAngles + Quaternion.Euler(90f, 0f, 0f).eulerAngles;
        vector.gameObject.transform.rotation = Quaternion.Euler(newRotation);
        vector.SetScale(rb.velocity.magnitude * 0.2f);

        if (isMoving)
        {
            interactiveObjectButton.SetActive(false);
            vector.gameObject.SetActive(true);
        }
        else
        {
            interactiveObjectButton.SetActive(true);
            vector.gameObject.SetActive(false);
        }
    }

    public override void OnArrowDown()
    {
        if (!isMoving && focused)
        {
            scale -= 0.1f;

            if (scale < 0.3f)
                scale = 0.3f;

            sphere.transform.localScale = new Vector3(scale, scale, scale);

            rb.mass -= 1f;

            if (rb.mass < 3f)
                rb.mass = 3f;
        }
    }

    public override void OnArrowUp()
    {
        if (!isMoving && focused)
        {
            scale += 0.1f;

            if (scale > 1.7f)
                scale = 1.7f;

            sphere.transform.localScale = new Vector3(scale, scale, scale);

            rb.mass += 1f;

            if (rb.mass > 17f)
                rb.mass = 17f;
        }

    }

    public void ResetPosition()
    {
        isMoving = false;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        transform.position = originalPosition;
    }

    public void StartAddForce()
    {
        rb.AddForce(Vector3.left * 130, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.PlaySound(SoundType.Toc);
    }

    public override void OnClick()
    {
    }

    void OnDisable()
    {
        sphere.transform.localScale = Vector3.one;
        rb.mass = 10f;
        ResetPosition();
        isMoving = false;
    }
}
