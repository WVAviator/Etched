using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Etched
{
    public class Score : MonoBehaviour
    {
        List<Word> words = new List<Word>();
        TextMeshProUGUI scoreText;

        void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
            
        }

        void OnEnable()
        {
            WordEvaluator.OnNewWordFound += AddWord;
        }

        void OnDisable()
        {
            WordEvaluator.OnNewWordFound -= AddWord;
        }

        void AddWord(Word word)
        {
            words.Add(word);
            int totalScore = 0;
            foreach (Word w in words) totalScore += w.Score;
            string scoreString = $"Score: {totalScore:D8}\n";
            string wordsFound = "";
            foreach (Word w in words)
            {
                wordsFound += w.String + "   ";
                wordsFound += w.Score + "\n";
            }

            scoreText.text = scoreString + wordsFound;
        }
    }
}