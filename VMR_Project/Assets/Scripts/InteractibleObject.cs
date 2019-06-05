using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractibleObject : MonoBehaviour
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
        if (Input.GetKey(KeyCode.Space) && focused)
            OnClick();

        if (Input.GetKey(KeyCode.UpArrow) && focused)
            OnArrowUp();

        if (Input.GetKey(KeyCode.DownArrow) && focused)
            OnArrowDown();
    }

    protected abstract void OnClick();
    protected abstract void OnArrowUp();
    protected abstract void OnArrowDown();
}
