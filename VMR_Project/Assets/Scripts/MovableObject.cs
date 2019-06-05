using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : InteractiveObject
{
    public GameObject controller;

    private float baseAngle;
    private Vector3 originalPosition;
    private Rigidbody rb;

    private bool dragged;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (dragged)
        {
            float distance = Vector3.Distance(originalPosition, controller.transform.position);
            float angle = baseAngle + controller.transform.rotation.eulerAngles.x;
            if (angle > 0.000001f || angle < -0.000001f)
            {
                float movement = distance / Mathf.Sin(-angle);
                this.transform.position = originalPosition + new Vector3(0, movement, 0);
            }

        }

    }

    protected override void OnArrowDown()
    {
    }

    protected override void OnArrowUp()
    {
    }

    protected override void OnClick()
    {
        Debug.Log("Dragged!");

        dragged = !dragged;

        if (dragged)
            baseAngle = controller.transform.rotation.eulerAngles.x;
    }
}
