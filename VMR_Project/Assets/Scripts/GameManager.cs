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
    public GameObject[] experiences;
    public Sprite[] experiencesSprites;

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
                    if (OVRInput.Get(OVRInput.Button.Any) || Input.GetKeyDown(KeyCode.N))
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

                    for (int i = 0; i < 10; ++i)
                    {
                        if (Input.GetKeyDown("" + i))
                        {
                            GoToExperience(i);
                        }
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
        AudioManager.instance.PlaySound(SoundType.HardPop);
        mainMenuObjects.SetActive(false);
        gameStatus = GameStatus.InExperience;
        experiences[experienceIndex].SetActive(true);
        currentExperience = experiences[experienceIndex];
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

    public void OnOverButton(int buttonIndex)
    {
        mainMenuSignBoard.sprite = experiencesSprites[buttonIndex];
    }



}
