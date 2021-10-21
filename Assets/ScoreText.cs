using System;
using System.Collections;
using System.Collections.Generic;
using Etched;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{

    TextMeshProUGUI _textMeshProUGUI;

    void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        Score.OnScoreChanged += UpdateScore;
    }

    void OnDisable()
    {
        Score.OnScoreChanged -= UpdateScore;
    }

    void UpdateScore(int score)
    {
        _textMeshProUGUI.text = score.ToString();
    }
}
