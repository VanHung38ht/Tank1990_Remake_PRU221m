using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.EventSystems;

public class intruct : MonoBehaviour
{
    public GameObject intructmenu, menu, option;

    public static class GameStatus
    {
        public static bool isGamePaused = true;
        public static bool isTankCreate = false;
        public static bool isTankPlay = true;
    }

    void Start()
    {
        menu.SetActive(true);
        //Clear Object selected
        EventSystem.current.SetSelectedGameObject(null);
        // Choose a new selected object
        EventSystem.current.SetSelectedGameObject(option);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            intructmenu.SetActive(true);

            Time.timeScale = 0;
            GameStatus.isGamePaused = true;
        }

        if (Input.GetKey(KeyCode.C))
        {
            intructmenu.SetActive(false);
            Time.timeScale = 1f;
            GameStatus.isGamePaused = false;
            GameStatus.isTankCreate = true;
        }
    }

    public void option1()
    {
        menu.SetActive(false);
        intructmenu.SetActive(true);
    }

    public void option2()
    {
        menu.SetActive(true);
        //Clear Object selected
        EventSystem.current.SetSelectedGameObject(null);
        // Choose a new selected object
        EventSystem.current.SetSelectedGameObject(option);
    }
}
