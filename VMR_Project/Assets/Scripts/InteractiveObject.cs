using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    private bool focused;

    public void OnFocusEnter()
    {
        focused = true;
    }

    public void OnFocusExit()
    {
        focused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnClick();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            OnArrowUp();

        if (Input.GetKeyDown(KeyCode.DownArrow))
            OnArrowDown();
    }

    protected abstract void OnClick();
    protected abstract void OnArrowUp();
    protected abstract void OnArrowDown();
}
