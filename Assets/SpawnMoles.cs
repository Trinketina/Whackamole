using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class SpawnMoles : MonoBehaviour
{
    [SerializeField] GameObject molePrefab;

    [SerializeField] TMP_Text timerText;

    [SerializeField] float timer = 360;
    float elapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "TIME " + ((int)timer).ToString("D4");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = "TIME " + ((int)timer).ToString("D4");

            elapsed += Time.deltaTime;

            if (elapsed > 2)
            {
                GameObject g = Instantiate(molePrefab, this.transform);
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                rectTransform.anchoredPosition = new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
                Debug.Log(rectTransform.anchoredPosition);

                elapsed = 0;
            }
        }
    }
}
