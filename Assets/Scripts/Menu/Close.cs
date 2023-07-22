using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Close : MonoBehaviour
{
    public GameObject close;
    // Start is called before the first frame update
    public void Closed()
    {
        //Clear Object selected
        EventSystem.current.SetSelectedGameObject(null);
        // Choose a new selected object
        EventSystem.current.SetSelectedGameObject(close);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void setMap()
    {
        ChooseMap chooseMap = FindObjectOfType<ChooseMap>();
        chooseMap.map = 0;
    }
}
