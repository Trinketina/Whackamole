using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField]
    int scoreMultiplier = 1;

    Score scoreScript;
    // Start is called before the first frame update
    void Start()
    {
        scoreScript = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        scoreScript.UpdateScore(scoreMultiplier);
        Destroy(this.gameObject);
    }

}
