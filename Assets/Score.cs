using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    TMP_Text hiScore;
    [SerializeField]
    TMP_Text currScore;
    int score = 0;
    [SerializeField]
    TMP_Text currMoles;
    int moles = 0;

    float timeMultiplier = 0;
    bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            timeMultiplier += Time.deltaTime * 0.3f;
        }
    }
    public void UpdateScore(int multiplier)
    {
        if (running)
        {
            moles++;
            currMoles.text = moles.ToString("D4");
            currScore.text = CalcScore(multiplier).ToString("D9");
        }
    }

    int CalcScore(int multiplier)
    {
        switch (moles)
        {
            case <5:
                score+= 1 * multiplier + ((int)timeMultiplier);
                return score;
            case <10:
                score += 2 * multiplier + ((int)timeMultiplier);
                return score;
            case <20:
                score += 3 * multiplier + ((int)timeMultiplier);
                return score;
            case <35:
                score += 4 * multiplier + ((int)timeMultiplier);
                return score;
            case <50:
                score += 5 * multiplier + ((int)timeMultiplier);
                return score;
            case <75:
                score += 7 * multiplier + ((int)timeMultiplier);
                return score;
            case <100:
                score += 10 * multiplier + ((int)timeMultiplier);
                return score;
            case >100:
                score += 11 * multiplier + ((int)timeMultiplier);
                return score;
            default:
                return score += 12 * multiplier + ((int)timeMultiplier);
        }
    }

    public void EndScore()
    {
        running = false;
        timeMultiplier = 0;
        score = 0;
        moles = 0;

        if (int.Parse(hiScore.text) < int.Parse(currScore.text))
            hiScore.text = currScore.text;

    }
    public void StartScore()
    {
        currScore.text = 0.ToString("D9");
        currMoles.text = 0.ToString("D4");
        running = true;

    }
}
