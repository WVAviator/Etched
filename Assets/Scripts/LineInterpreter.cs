using System;
using System.Collections.Generic;
using UnityEngine;

namespace Etched
{
    public class LineInterpreter
    {
        Vector2Int _startPos;
        Vector2Int _endPos;

        public string Word => GetWordBetween();

        public List<LetterBlock> LetterBlocks => _letterBlocks;
        List<LetterBlock> _letterBlocks = new List<LetterBlock>();

        public LineInterpreter(LetterBlock startBlock, LetterBlock endBlock)
        {
            Update(startBlock.LetterPosition, endBlock.LetterPosition);
        }

        public LineInterpreter(Vector2Int startPos, Vector2Int endPos)
        {
            Update(startPos, endPos);
        }

        public void Update(Vector2Int startPos, Vector2Int endPos)
        {
            _startPos = startPos;
            _endPos = endPos;
        }

        string GetWordBetween()
        {
            _letterBlocks.Clear();
            string result = "";
            
            int dirX = Math.Sign(_endPos.x - _startPos.x);
            int dirY = Math.Sign(_endPos.y - _startPos.y);

            Vector2Int current = _startPos;
            Vector2Int direction = new Vector2Int(dirX, dirY);
            Vector2Int target = _endPos + direction;

            while (current != target)
            {
                LetterBlock block = LetterBlock.GetBlock(current);
                result += block.Letter;
                _letterBlocks.Add(block);
                current += direction;
            }

            return result;
        }
        public bool IsValidLine()
        {
            return AreAdjacent(_startPos, _endPos) ||
                   AreDiagonal(_startPos, _endPos);
        }
        
        bool AreDiagonal(Vector2Int a, Vector2Int b)
        {
            return Mathf.Abs(a.x - b.x) == Mathf.Abs(a.y - b.y);
        }

        bool AreAdjacent(Vector2Int a, Vector2Int b)
        {
            return a.x == b.x || a.y == b.y;
        }
    }
}
