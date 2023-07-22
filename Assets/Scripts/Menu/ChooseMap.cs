using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMap : MonoBehaviour
{
    public int map = 0;
    [SerializeField] private AudioSource SelectSound;


    public void chooseCreateMap()
    {
        SelectSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void chooseMap1()
    {
        SelectSound.Play();

        map = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void chooseMap2()
    {
        SelectSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void chooseMap3()
    {
        
        SelectSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void chooseMap4()
    {
        map = 4;

        SelectSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }
    public void backFromCreateMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1.0f;
    }
    public void backFromMap1()
    {
        map = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1.0f;
    }
    public void backFromMap2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        Time.timeScale = 1.0f;
    }
    public void backFromMap3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        Time.timeScale = 1.0f;
    }
    public void quit() { Debug.Log("Quit!"); }
}
