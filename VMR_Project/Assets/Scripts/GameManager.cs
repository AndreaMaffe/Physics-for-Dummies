using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    OnTitleScreen,
    OnMainMenu,
    InExperience
}

public class GameManager : MonoBehaviour
{
    private GameStatus gameStatus;
    private GameObject currentExperience;

    public FadingText title, subtitle;
    public GameObject mainMenuObjects;
    public SpriteRenderer mainMenuSignBoard;
    public GameObject experience0;
    public GameObject experience1;
    public GameObject experience2;
    public GameObject experience3;


    public Sprite[] experiencesSprites;
    public GameObject[] mainMenuButtons;

    private bool busy;

    void Start()
    {
        gameStatus = GameStatus.OnTitleScreen;
        title.gameObject.SetActive(true);
        subtitle.gameObject.SetActive(true);
        mainMenuObjects.SetActive(false);
        busy = false;
    }

    void Update()
    {
        switch (gameStatus)
        {
            case GameStatus.OnTitleScreen:
                {
                    if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.N))
                    {
                        if (!busy)
                        {
                            busy = true;
                            StartCoroutine(GoToMainMenu());
                        }
                    }
                }

                break;

            case GameStatus.OnMainMenu:
                {
                    if (OVRInput.Get(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.B))
                    {
                        BackToTitleScreen();
                    }
                }
                break;

            case GameStatus.InExperience:
                {
                    if (OVRInput.Get(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.B))
                    {
                        BackToMainMenu();
                    }
                }

                break;
        }
    }

    //TitleScreen --> MainMenu
    private IEnumerator GoToMainMenu()
    {
        AudioManager.instance.PlaySound(SoundType.Pop);
        title.Fade();
        subtitle.Fade();
        yield return new WaitForSeconds(2);
        AudioManager.instance.PlaySound(SoundType.HardPop);
        gameStatus = GameStatus.OnMainMenu;
        mainMenuObjects.SetActive(true);
        busy = false;
    }

    //MainMenu --> Experience
    public void GoToExperience(int experienceIndex)
    {
        /*
        if (gameStatus == GameStatus.OnMainMenu)
        {
            //int experienceIndex = Array.IndexOf(mainMenuButtons, experienceButton);
            Debug.Log("Carico l'esperienza " + experienceIndex);
            AudioManager.instance.PlaySound(SoundType.HardPop);
            mainMenuObjects.SetActive(false);
            gameStatus = GameStatus.InExperience;
            experiences[experienceIndex].SetActive(true);
            currentExperience = experiences[experienceIndex];
        }
        */
    }

    //MainMenu <-- Experience
    private void BackToMainMenu()
    {
        AudioManager.instance.PlaySound(SoundType.HardPop);
        currentExperience.SetActive(false);
        gameStatus = GameStatus.OnMainMenu;
        mainMenuObjects.SetActive(true);
    }

    //TitleScreen <-- MainMenu
    private void BackToTitleScreen()
    {
        AudioManager.instance.PlaySound(SoundType.Pop);        
        mainMenuObjects.SetActive(false);
        gameStatus = GameStatus.OnTitleScreen;
        title.Restore();
        subtitle.Restore();
    }

    public void OnOverButton(GameObject button)
    {
        if (button == null)
            mainMenuSignBoard.sprite = experiencesSprites[9];
        else
        {
            int buttonIndex = Array.IndexOf(mainMenuButtons, button);
            mainMenuSignBoard.sprite = experiencesSprites[buttonIndex];
        }

    }

    public void GoToExperience0()
    {
        if (gameStatus == GameStatus.OnMainMenu)
        {
            //int experienceIndex = Array.IndexOf(mainMenuButtons, experienceButton);
            Debug.Log("Carico l'esperienza " + 0);
            AudioManager.instance.PlaySound(SoundType.HardPop);
            mainMenuObjects.SetActive(false);
            gameStatus = GameStatus.InExperience;
            experience0.SetActive(true);
            currentExperience = experience0;
        }
    }

    public void GoToExperience1()
    {
        if (gameStatus == GameStatus.OnMainMenu)
        {
            //int experienceIndex = Array.IndexOf(mainMenuButtons, experienceButton);
            Debug.Log("Carico l'esperienza " + 1);
            AudioManager.instance.PlaySound(SoundType.HardPop);
            mainMenuObjects.SetActive(false);
            gameStatus = GameStatus.InExperience;
            experience1.SetActive(true);
            currentExperience = experience1;
        }
    }

    public void GoToExperience2()
    {
        if (gameStatus == GameStatus.OnMainMenu)
        {
            //int experienceIndex = Array.IndexOf(mainMenuButtons, experienceButton);
            Debug.Log("Carico l'esperienza " + 2);
            AudioManager.instance.PlaySound(SoundType.HardPop);
            mainMenuObjects.SetActive(false);
            gameStatus = GameStatus.InExperience;
            experience2.SetActive(true);
            currentExperience = experience2;

            Debug.Log("Caico la 2");
        }
    }



}
