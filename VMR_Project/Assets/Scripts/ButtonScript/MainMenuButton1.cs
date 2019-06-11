using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton1 : InteractiveObject
{
    public Animator animator;
    public GameManager gameManager;

    public override void OnFocusEnter()
    {
        Debug.Log(gameObject.name + "focused!");
        focused = true;
        animator.SetBool("Focused", true);
        gameManager.OnOverButton(this.gameObject);
        AudioManager.instance.PlaySound(SoundType.Tic);
    }

    public override void OnFocusExit()
    {
        Debug.Log(gameObject.name + "stop focused!");
        focused = false;
        animator.SetBool("Focused", false);
        gameManager.OnOverButton(null); //default sheet
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
        {
            gameManager.GoToExperience1();
        }

    }
}
