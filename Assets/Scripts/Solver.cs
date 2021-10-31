using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Etched
{
    public class Solver : MonoBehaviour
    {
        int _rows = 8;
        int _columns = 8;
        int _minWordLength = 3;
        WordDictionary _wordDictionary;

        void Awake()
        {
            _wordDictionary = new WordDictionary();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) Solve();
        }
        char[,] GetCurrentBoard()
        {
            List<LetterBlock> blocksInBoard = LetterBlock.AllLetterBlocks.FindAll(b => b.LetterPosition.y < 8);
            blocksInBoard = blocksInBoard.OrderBy(b => b.LetterPosition.y).ThenBy(b => b.LetterPosition.x).ToList();
        
            //foreach (LetterBlock b in blocksInBoard) Debug.Log($"{b.LetterPosition} : {b.Letter}");

            char[,] board = new char[_rows,_columns];
        
            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _columns; x++)
                {
                    board[x, y] = blocksInBoard[x + y * _columns].Letter;
                }
            }

            return board;
        }

        HashSet<string> WordsInBoard(char[,] board)
        {
            HashSet<string> words = new HashSet<string>();

            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _columns; x++)
                {

                    string[] strs = new string[8];
                    for (int i = 0; i < Math.Max(_rows, _columns); i++)
                    {
                        //East
                        if (x + i < _columns)
                        {
                            strs[0] += board[x + i, y];
                            //Northeast
                            if (y + i < _rows) strs[1] += board[x + i, y + i];
                            //Southeast
                            if (y - i >= 0) strs[2] += board[x + i, y - i];
                        }
                        //West
                        if (x - i >= 0)
                        {
                            strs[3] += board[x - i, y];
                            //Northwest
                            if (y + i < _rows) strs[4] += board[x - i, y + i];
                            //Southwest
                            if (y - i >= 0) strs[5] += board[x - i, y - i];
                        }
                        //North
                        if (y + i < _rows) strs[6] += board[x, y + i];
                        //South
                        if (y - i >= 0) strs[7] += board[x, y - i];

                        foreach (string s in strs)
                        {
                            if (CheckString(s)) words.Add(s);
                        }
                    }
                }
            }

            return words;
        }

        void Solve()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
        
            char[,] board = GetCurrentBoard();
            HashSet<string> words = WordsInBoard(board);
        
            stopWatch.Stop();
        
            Debug.Log($"Found {words.Count} words in {stopWatch.ElapsedMilliseconds} milliseconds.");
            Debug.Log($"The longest is {words.OrderByDescending(w => w.Length).ToList()[0]}.");

            string output = "";
            foreach (string w in words) output += w + ", ";
            Debug.Log(output);
        }

        bool CheckString(string s)
        {
            if (s.Length < _minWordLength) return false;
            List<string> allSubstrings = new List<string>();
            for (int i = 3; i <= s.Length; i++)
            {
                allSubstrings.Add(s.Substring(0, i));
            }
        
            return _wordDictionary.IsInDictionary(s, _minWordLength);

        }
    
    }
}
