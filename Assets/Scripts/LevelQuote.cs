using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Etched
{
    [CreateAssetMenu(menuName = "Quote")]
    public class LevelQuote : ScriptableObject
    {
        [SerializeField] string quote;

        public string LetterString() => quote.OnlyLetters().ToUpper();

        public List<Word> Words()
        {
            string[] strings = quote.Split(' ');
            return strings.Select(s => new Word(s.OnlyLetters().ToUpper())).ToList();
        } 
    }
}