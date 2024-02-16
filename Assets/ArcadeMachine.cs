using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class ArcadeMachine : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField]
    bool started;
    bool reset = false;
    Quaternion rotated;
    [SerializeField]
    float time = 0;

    [SerializeField]
    Score score;
    [SerializeField]
    SpawnMoles spawnMoles;

    [SerializeField]
    GameObject startMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && !reset)
        {
            Rotate();
        }
        else if (reset)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 90, -35), Quaternion.Euler(0, 90, 0), time);
            time += Time.deltaTime;
            if (time > 1)
            {
                reset = false;
                time = 0;
            }
        }
        else
        {
            time += Time.deltaTime * 2;
            transform.rotation = Quaternion.Lerp(rotated, Quaternion.Euler(0, 90, -35), time);
        }
    }

    void Rotate()
    {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            rotated = transform.rotation;
    }

    [ContextMenu("Reset Time")]
    public void ResetTime()
    {
        time = 0;
        started = false;
        reset = true;
        startMenu.gameObject.SetActive(true);
        spawnMoles.EndGame();
    }

    public void RotateToStart()
    {
        started = true;
        spawnMoles.StartGame();
        score.StartScore();
        startMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
