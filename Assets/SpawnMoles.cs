using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnMoles : MonoBehaviour
{
    [SerializeField] GameObject molePrefab;

    [SerializeField] TMP_Text timerText;

    [SerializeField] float startTime = 360;
    float timer;
    float elapsed = 0;
    bool running = false;

    [SerializeField]
    GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        timer = startTime;
        timerText.text = "TIME    " + ((int)timer).ToString("D4");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && running)
        {
            timer -= Time.deltaTime;
            timerText.text = "TIME    " + ((int)timer).ToString("D4");

            elapsed += Time.deltaTime;

            float range;
            switch (timer / startTime)
            {
                case > 0.9f:
                    MakeMole(Random.Range(1.7f, 2.3f));
                    break;
                case > 0.7f:
                    MakeMole(Random.Range(1.5f, 1.85f));
                    break;
                case > 0.5f:
                    MakeMole(Random.Range(1f, 1.5f));
                    break;
                case > 0.3f:
                    MakeMole(Random.Range(.8f, 1.3f));
                    break;
                default:
                    MakeMole(Random.Range(.4f, .7f));
                    break;
            }

            
        }
        else if (running)
        {
            EndGame();
        }
    }
    void MakeMole(float range)
    {
        if (elapsed >= range)
        {
            GameObject g = Instantiate(molePrefab, this.transform);
            RectTransform rectTransform = g.GetComponent<RectTransform>();

            rectTransform.anchoredPosition = new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
            Debug.Log(rectTransform.anchoredPosition);

            Destroy(g, Random.Range(range + range * .5f, range * 3.3f));

            elapsed = 0;
        }
    }

    public void EndGame()
    {
        FindObjectOfType<Score>().EndScore();
        running = false;
        timerText.text = "TIME    " + 0.ToString("D4");

        startButton.SetActive(true);
    }

    public void StartGame()
    {
        timer = startTime;
        running = true;
    }
}
