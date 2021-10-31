using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Etched
{
    public class AlphabetFrequency : MonoBehaviour
    {
        //[SerializeField] LevelLetters _levelLetters;
        [SerializeField] LevelQuote _levelQuote;
        string _weightedAlphabet;

        void Awake()
        {
            _weightedAlphabet = _levelQuote.LetterString();
        }

        public char GetRandomChar()
        {
            int random = Random.Range(0, _weightedAlphabet.Length);
            return _weightedAlphabet[random];
        }
        
    }
}
