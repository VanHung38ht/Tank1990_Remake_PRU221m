using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuOption : MonoBehaviour
{
    public GameObject optionGame, soundGame, option1Menu, option2Menu;
    public GameObject OptionGameFirst, SoundMenuFirst, Option1First, Option2First;

    public void MenuGame()
    {
        optionGame.SetActive(true);
        //Clear Object selected
        EventSystem.current.SetSelectedGameObject(null);
        // Choose a new selected object
        EventSystem.current.SetSelectedGameObject(OptionGameFirst);
    }

    public void SoundGame()
    {
        soundGame.SetActive(true);
        optionGame.SetActive(false);

        //Clear Object selected
        EventSystem.current.SetSelectedGameObject(null);
        // Choose a new selected object
        EventSystem.current.SetSelectedGameObject(SoundMenuFirst);
    }

    public void Option1Menu()
    {
        option1Menu.SetActive(true);
        optionGame.SetActive(false);

        //Clear Object selected
        EventSystem.current.SetSelectedGameObject(null);
        // Choose a new selected object
        EventSystem.current.SetSelectedGameObject(Option1First);
    }

    public void Option2Menu()
    {
        option2Menu.SetActive(true);
        optionGame.SetActive(false);

        //Clear Object selected
        EventSystem.current.SetSelectedGameObject(null);
        // Choose a new selected object
        EventSystem.current.SetSelectedGameObject(Option2First);
    }

    public void quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
}
