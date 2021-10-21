using System;
using System.Collections;
using System.Collections.Generic;
using Etched;
using UnityEngine;

public class ScoreBar : MonoBehaviour
{

    [SerializeField] SpriteRenderer emptyBar;
    [SerializeField] float highestScore = 250;
    [SerializeField] float barMoveSpeed = 1;
    SpriteRenderer bar;
    float maxWidth;
    float minWidth;
    float desiredWidth;
    

    void Awake()
    {
        bar = GetComponent<SpriteRenderer>();
        minWidth = bar.size.x;
        maxWidth = emptyBar.size.x;
        desiredWidth = minWidth;
    }
    void OnEnable()
    {
        Score.OnScoreChanged += UpdateScoreBar;
    }
    void OnDisable()
    {
        Score.OnScoreChanged -= UpdateScoreBar;
    }

    void Update()
    {
        if (Math.Abs(bar.size.x - desiredWidth) < 0.001) return;
        bar.size = Vector2.MoveTowards(bar.size, new Vector2(desiredWidth, bar.size.y), barMoveSpeed * Time.deltaTime);
    }

    void UpdateScoreBar(int score)
    {
        float scorePercent = score / highestScore;
        if (scorePercent > 1) scorePercent = 1;
        desiredWidth = scorePercent * (maxWidth - minWidth) + minWidth;
    }
}
