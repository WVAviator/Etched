using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Etched
{
    public class LineManager : MonoBehaviour
    {
        [SerializeField] LineRenderer _emptyLinePrefab;
        LineRenderer _activeLine;
        List<LetterBlock> _blocksInLine = new List<LetterBlock>();
        Collider2D _lastCollider;
        
        WordEvaluator _wordEvaluator;
        LineInterpreter _lineInterpreter;

        void Awake() => _wordEvaluator = new WordEvaluator();
        
        void OnEnable()
        {
            InputHandler.OnDrag += OnDrag;
            InputHandler.OnRelease += OnRelease;
        }

        void OnDisable()
        {
            InputHandler.OnDrag -= OnDrag;
            InputHandler.OnRelease -= OnRelease;
        }

        void OnDrag(DragInformation drag)
        {
            if (drag.IsNull) return;
            if (!ValidSelection(drag, out LetterBlock firstBlock, out LetterBlock lastBlock)) return;
            SetLinePositions(firstBlock.LetterPosition, lastBlock.LetterPosition);
            _lastCollider = drag.CurrentCollider;
        }

        void OnRelease(DragInformation drag)
        {
            
            if (_activeLine != null) Destroy(_activeLine.gameObject);

            if (_lastCollider == null) return;
            DragInformation updatedDrag = new DragInformation(drag.SelectedCollider, _lastCollider);
            if (!ValidSelection(updatedDrag, out LetterBlock firstBlock, out LetterBlock lastBlock)) return;
            _lastCollider = null;
            _lineInterpreter.Update(firstBlock.LetterPosition, lastBlock.LetterPosition);
            if (!_lineInterpreter.IsValidLine()) return;

            _blocksInLine = _lineInterpreter.LetterBlocks;
            if (_wordEvaluator.Evaluate(_lineInterpreter.Word)) _blocksInLine.ForEach(b => b.SelfDestruct());
            _blocksInLine.Clear();
            
        }

        bool ValidSelection(DragInformation drag, out LetterBlock first, out LetterBlock last)
        {
            first = drag.SelectedCollider.GetComponent<LetterBlock>();
            last = drag.CurrentCollider.GetComponent<LetterBlock>();
            return first != null && last != null && first != last;
        }

        void InstantiateLine()
        {
            _activeLine = Instantiate(_emptyLinePrefab);
            _activeLine.positionCount = 2;
        }

        void SetLinePositions(Vector2Int a, Vector2Int b)
        {
            if (_activeLine == null)
            {
                InstantiateLine();
                _lineInterpreter = new LineInterpreter(a, b);
            }
            else _lineInterpreter.Update(a, b);
            
            if (!_lineInterpreter.IsValidLine())
            {
                _activeLine.enabled = false;
                return;
            }
            _activeLine.enabled = true;
            Vector3[] positions = {new Vector3(a.x, a.y, -2f), new Vector3(b.x, b.y, -2f)};
            _activeLine.SetPositions(positions);
        }

    }
}