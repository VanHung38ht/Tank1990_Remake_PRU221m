using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class settingSound : MonoBehaviour
{
    [SerializeField] AudioSource sound;

    public void on()
    {
        sound.Play();
    }
    public void off()
    {
        sound.Stop();
    }
}
