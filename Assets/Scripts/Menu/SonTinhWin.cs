using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SonTinhWin : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene(0);
    }
}
