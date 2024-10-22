﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class InteractiveObject : MonoBehaviour
{
    protected bool focused;

    public virtual void OnFocusEnter()
    {
        Debug.Log(gameObject.name + "focused!");
        focused = true;
    }

    public virtual void OnFocusExit()
    {
        Debug.Log(gameObject.name + "stop focused!");
        focused = false;
    }

    private void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
            OnClick();

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            OnClick();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            OnArrowUp();

        if (Input.GetKeyDown(KeyCode.DownArrow))
            OnArrowDown();      

        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);

            if (coord.y > 0.22f)
                OnArrowUp();
            else if (coord.y < -0.22f)
                OnArrowDown();
        }
    }

    public abstract void OnClick();
    public abstract void OnArrowUp();
    public abstract void OnArrowDown();
}
