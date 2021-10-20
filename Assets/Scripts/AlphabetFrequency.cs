using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Etched
{
    public class AlphabetFrequency : MonoBehaviour
    {
        [SerializeField] LevelLetters _levelLetters;
        string weightedAlphabet;

        void Awake()
        {
            weightedAlphabet = _levelLetters.AlphabetDistributionString();
        }

        public char GetRandomChar()
        {
            int random = Random.Range(0, weightedAlphabet.Length);
            return weightedAlphabet[random];
        }
        
    }
}
