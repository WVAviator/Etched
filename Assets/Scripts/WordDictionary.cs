using System.Collections.Generic;
using UnityEngine;

namespace Etched
{
    public class WordDictionary {

        HashSet<string> words = new HashSet<string>();

        TextAsset dictText;

        public WordDictionary(){
            InitializeDictionary("ospd");
        }

        public WordDictionary(string filename){
            InitializeDictionary(filename);
        }

        void InitializeDictionary(string filename){
            dictText = (TextAsset) Resources.Load(filename, typeof (TextAsset));
            var text = dictText.text;

            foreach (string s in text.Split('\n')){
                words.Add(s);
            }
        }
	
        public bool IsInDictionary(string word, int minLength){
            if (word.Length < minLength){
                return false;
            }

            return (words.Contains(word));
        }
    }
}
