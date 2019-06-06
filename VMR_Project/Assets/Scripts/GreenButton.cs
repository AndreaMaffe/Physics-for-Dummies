using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : InteractiveObject
{
    public Animator animator;
    public int index;

    public override void OnFocusEnter()
    {
        Debug.Log(gameObject.name + "focused!");
        focused = true;
        animator.SetBool("Focused", true);
    }

    public override void OnFocusExit()
    {
        Debug.Log(gameObject.name + "stop focused!");
        focused = false;
        animator.SetBool("Focused", false);
    }

    public override void OnArrowDown()
    {
    }

    public override void OnArrowUp()
    {
    }

    public override void OnClick()
    {

    }
}
