using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Image scoreBar;
    public float currentScore;
    public float maxScore = 2000f;
    GameManager Game;

    // Start is called before the first frame update
    void Start()
    {
        scoreBar = GetComponent<Image>();
        Game = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        currentScore = Game.currentScore;
        scoreBar.fillAmount = currentScore / maxScore;
    }
}
