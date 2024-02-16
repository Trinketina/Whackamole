using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq.Expressions;
using Unity.VisualScripting.Antlr3.Runtime;

public class Score : MonoBehaviour
{
    [SerializeField]
    TMP_Text hiScore;
    [SerializeField]
    TMP_Text currTime;
    [SerializeField]
    TMP_Text currScore;
    int score = 0;
    [SerializeField]
    TMP_Text currMoles;
    int moles = 0;

    float timeMultiplier = 0;

    float tempTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeMultiplier += Time.deltaTime*0.3f;
        //Debug.Log(timeMultiplier);

        tempTimer += Time.deltaTime;
        
    }
    public void UpdateScore()
    {
        moles++;
        currMoles.text = moles.ToString("D4");
        currScore.text = CalcScore().ToString("D9");
    }

    int CalcScore()
    {
        switch (moles)
        {
            case <5:
                score+= 1 + ((int)timeMultiplier);
                return score;
            case <10:
                score += 2 + ((int)timeMultiplier);
                return score;
            case <20:
                score += 3 + ((int)timeMultiplier);
                return score;
            case <35:
                score += 4 + ((int)timeMultiplier);
                return score;
            case <50:
                score += 5 + ((int)timeMultiplier);
                return score;
            case <75:
                score += 7 + ((int)timeMultiplier);
                return score;
            case <100:
                score += 10 + ((int)timeMultiplier);
                return score;
            case >100:
                score += 11 + ((int)timeMultiplier);
                return score;
            default:
                return score += 12 + ((int)timeMultiplier);
        }
    }
}
