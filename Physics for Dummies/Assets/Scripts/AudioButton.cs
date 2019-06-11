using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : InteractiveObject
{
    public Animator animator;
    public int lessonIndex;

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
        if (focused)
            AudioManager.instance.PlayLesson(lessonIndex);
    }

    private void OnDisable()
    {
        AudioManager.instance.StopAudio();
        focused = false;
    }
}
