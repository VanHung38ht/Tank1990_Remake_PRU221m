using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text m_Score;


    public void textScore(string text)
    {
        if (m_Score)
        {
            m_Score.text = text;
        }
    }
}
