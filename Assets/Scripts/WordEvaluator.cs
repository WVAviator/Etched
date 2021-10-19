using System;
using UnityEngine;

namespace Etched
{
    public class WordEvaluator
    {
        public static event Action<Word> OnNewWordFound;
        WordDictionary _wordDictionary;
        int _minWordLength = 3;

        public WordEvaluator()
        {
            _wordDictionary = new WordDictionary();
        }
        public bool Evaluate(string wordToEvaluate)
        {
            if (_wordDictionary.IsInDictionary(wordToEvaluate, _minWordLength))
            {
                OnNewWordFound?.Invoke(new Word(wordToEvaluate));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
