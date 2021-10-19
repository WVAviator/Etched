using System.Collections.Generic;
using System.IO;

namespace Etched
{
    public class LetterScore
    {
        static readonly Dictionary<char, int> LetterPoints;
        static int wordLengthMultiplier = 2;

        static LetterScore()
        {
            LetterPoints = GetLetterPoints();
        }
        static Dictionary<char, int> GetLetterPoints()
        {
            Dictionary<char, int> letterPoints = new Dictionary<char, int>();
        
            using (StreamReader reader = new StreamReader("Assets/Resources/letter_values.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    letterPoints.Add(values[0][0], int.Parse(values[1]));
                }
            }
            return letterPoints;
        }

        static int GetPoints(char c)
        {
            return LetterPoints[c];
        }

        public static int GetScore(string word)
        {
            int score = 0;
            for (int i = 0; i < word.Length; i++)
            {
                score += GetPoints(word[i]);
                if (i > 2) score *= wordLengthMultiplier;
            }

            return score;
        }
    }
}