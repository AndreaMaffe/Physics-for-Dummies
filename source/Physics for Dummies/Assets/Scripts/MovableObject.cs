using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : InteractiveObject
{
    public GameObject controller;
    public GameObject interactiveButton;

    private float baseAngle;
    private Vector3 originalPosition;
    private Rigidbody rb;

    private bool dragged;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        dragged = false;
    }

    private void FixedUpdate()
    {        
        if (dragged)
        {
            interactiveButton.SetActive(false);
            float distance = Vector3.Distance(originalPosition, controller.transform.position);
            float angle = baseAngle -GetControllerRotationX();
            if (Mathf.Abs(angle) > 0.000001f && Mathf.Abs(angle) < 80f)
            {
                float movement = distance * Mathf.Tan(Mathf.Deg2Rad*angle);
                this.transform.position = originalPosition + new Vector3(0, movement, 0);
            }
        }  

        else
        {
            interactiveButton.SetActive(true);
        }
    }

    public override void OnArrowDown()
    {
    }

    public override void OnArrowUp()
    {
    }

    public override void OnClick()
    {       
        if (dragged)
        {
            AudioManager.instance.PlaySound(SoundType.Pop);
            Debug.Log("Released!");
            dragged = false;
            rb.isKinematic = false;
        }

        else
        {
            if (focused)
            {
                AudioManager.instance.PlaySound(SoundType.Pop);
                Debug.Log("Dragged!");
                dragged = true;
                baseAngle = GetControllerRotationX();
                rb.isKinematic = true;
            }
        }        
    }

    private float GetControllerRotationX()
    {
        Vector3 angle = controller.transform.eulerAngles;
        float x = angle.x;

        if (Vector3.Dot(controller.transform.up, Vector3.up) >= 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = angle.x - 360f;
            }
        }
        else
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = 180 - angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = 180 - angle.x;
            }
        }

        return x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.PlaySound(SoundType.Toc);
    }

    private void OnDisable()
    {
        dragged = false;
        focused = false;
    }
}
