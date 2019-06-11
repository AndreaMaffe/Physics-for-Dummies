using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : InteractiveObject
{
    public Animator animator;

    public override void OnArrowDown()
    {
    }

    public override void OnArrowUp()
    {
    }

    public override void OnClick()
    {
        if (focused)
        {
            animator.SetTrigger("Pressed");
            AudioManager.instance.PlaySound(SoundType.Ding);
        }
    }
}
