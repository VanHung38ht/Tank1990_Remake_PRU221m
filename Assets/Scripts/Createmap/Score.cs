using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : TankController
{
    public Text count, score;

    // Start is called before the first frame update
    void Start()
    {
        count.text = Score.countDestroy.ToString();
        score.text = Score.score.ToString();
    }
}
