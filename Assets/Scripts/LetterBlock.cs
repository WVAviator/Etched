using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Etched
{
    public class LetterBlock : MonoBehaviour
    {

        TextMeshProUGUI _textMeshPro;

        LetterBlockMover _letterBlockMover;
    
        string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public char Letter => _letter;
        char _letter;

        Vector2Int _letterPosition;

        public Vector2Int LetterPosition => _letterPosition;

        public static List<LetterBlock> AllLetterBlocks = new List<LetterBlock>();
        void OnEnable() => AllLetterBlocks.Add(this);
        void OnDisable() => AllLetterBlocks.Remove(this);

        void Awake()
        {
            _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
            AdoptRandomLetter();
            _letterPosition =
                new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
            _letterBlockMover = GetComponent<LetterBlockMover>();
        }

        public static bool LetterBlockAtPosition(Vector2Int v)
        {
            return AllLetterBlocks.FirstOrDefault(b => b.LetterPosition == v) != null;
        }

        public static LetterBlock GetBlock(Vector2Int v) => AllLetterBlocks.FirstOrDefault(b => b.LetterPosition == v);

        void Update()
        {
            if (_letterPosition.y > 0 && ToSouth() == null)
            {
                Descend();
            }
        }

        void Descend()
        {
            _letterBlockMover.SetTargetPosition(_letterPosition + Vector2.down);
            _letterPosition += Vector2Int.down;
        }

        public void SelfDestruct()
        {
            foreach (LetterBlock b in AllLetterBlocks)
            {
                if (b.LetterPosition.y > _letterPosition.y && b.LetterPosition.x == _letterPosition.x) b.Descend();
            }
            Destroy(gameObject);
        }

        void AdoptRandomLetter()
        {
            _letter = AlphabetFrequency.GetRandomChar();
            _textMeshPro.text = Char.ToString(_letter);
        }

        char GetRandomChar()
        {
            return _alphabet[Random.Range(0, 26)]; //TODO: Needs to be weighted based on letter
        }
    
        public LetterBlock ToNorth()
        {
            return AllLetterBlocks.FirstOrDefault(p =>
                p.LetterPosition.y == _letterPosition.y + 1 && p.LetterPosition.x == _letterPosition.x);
        }
        public LetterBlock ToSouth()
        {
            return AllLetterBlocks.FirstOrDefault(p =>
                p.LetterPosition.y == _letterPosition.y - 1 && p.LetterPosition.x == _letterPosition.x);
        }
        public LetterBlock ToEast()
        {
            return AllLetterBlocks.FirstOrDefault(p =>
                p.LetterPosition.y == _letterPosition.y && p.LetterPosition.x == _letterPosition.x + 1);
        }
        public LetterBlock ToWest()
        {
            return AllLetterBlocks.FirstOrDefault(p =>
                p.LetterPosition.y == _letterPosition.y && p.LetterPosition.x == _letterPosition.x - 1);
        }
    }
}