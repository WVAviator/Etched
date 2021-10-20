using System.Collections.Generic;
using UnityEngine;

namespace Etched
{
    [CreateAssetMenu(menuName = "LetterBlock/Level Letter Frequency")]
    public class LevelLetters : ScriptableObject
    {
        [SerializeField] int A = 16;
        [SerializeField] int B = 3;
        [SerializeField] int C = 5;
        [SerializeField] int D = 8;
        [SerializeField] int E = 26;
        [SerializeField] int F = 4;
        [SerializeField] int G = 4;
        [SerializeField] int H = 6;
        [SerializeField] int I = 7;
        [SerializeField] int J = 1;
        [SerializeField] int K = 2;
        [SerializeField] int L = 8;
        [SerializeField] int M = 5;
        [SerializeField] int N = 13;
        [SerializeField] int O = 15;
        [SerializeField] int P = 4;
        [SerializeField] int Q = 0;
        [SerializeField] int R = 12;
        [SerializeField] int S = 13;
        [SerializeField] int T = 18;
        [SerializeField] int U = 5;
        [SerializeField] int V = 2;
        [SerializeField] int W = 5;
        [SerializeField] int X = 0;
        [SerializeField] int Y = 4;
        [SerializeField] int Z = 0;

        List<int> AlphabetDistributionList()
        {
            List<int> alphabetList = new List<int>()
            {
                A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
            };
            return alphabetList;
        }

        public string AlphabetDistributionString()
        {
            List<int> alphabetDistributionList = AlphabetDistributionList();
            string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string outputString = "";
            for (int i = 0; i < alphabetString.Length; i++)
            {
                for (int j = 0; j < alphabetDistributionList[i]; j++)
                {
                    outputString += alphabetString[i];
                }
            }

            return outputString;
        }
    }
}