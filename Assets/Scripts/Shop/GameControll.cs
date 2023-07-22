using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_score ;
    bool m_isOver;
    //UI m_UI;
    public Text m_UI;
    float power;
    void Start()
    {   
     
        m_score = 0;
        m_UI.text = m_score.ToString();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Reset()
    {

        m_score = 0;
        m_UI.text=m_score.ToString();

    }

    public void incrementSscore()
    {
        m_score+=5;
        m_UI.text = m_score.ToString();
    }
}
