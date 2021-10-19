using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Etched
{
    public class AlphabetFrequency
    {
        static Dictionary<char, float> LetterChances;
        static string WeightedAlphabet;

        static AlphabetFrequency()
        {
            LetterChances = GetLetterChances();
            WeightedAlphabet = DistributedLetterString();
        }
    
        static Dictionary<char, float> GetLetterChances()
        {
            Dictionary<char, float> letterChances = new Dictionary<char, float>();
        
            using (StreamReader reader = new StreamReader("Assets/Resources/LF_english.csv"))
            {
            

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    letterChances.Add(values[0][0], float.Parse(values[1].Substring(0, values[1].Length - 1)) / 100);
                }
            }

            return letterChances;
        }

        static string DistributedLetterString()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string weightedAlphabet = "";
            for (int i = 0; i < alphabet.Length; i++)
            {
                float percent = LetterChances[alphabet[i]];
                int distrbution = Mathf.RoundToInt(percent * 1000);

                for (int j = 0; j < distrbution; j++)
                {
                    weightedAlphabet += alphabet[i];
                }
            }
            return weightedAlphabet;
        }

        public static char GetRandomChar()
        {
            int random = Random.Range(0, WeightedAlphabet.Length);
            return WeightedAlphabet[random];
        }

        public static float CharChance(char c)
        {
            return LetterChances[c];
        }


    }
}
