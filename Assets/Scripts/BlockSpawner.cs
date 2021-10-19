using UnityEngine;

namespace Etched
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] LetterBlock _blockPrefab;
        [SerializeField] GameObject _gameBoard;
        
        Vector2Int _spawnPosition;
    
        void Awake()
        {
            _spawnPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        }
        
        void Update()
        {
            if (!LetterBlock.LetterBlockAtPosition(_spawnPosition)) SpawnBlock();
        }

        void SpawnBlock()
        {
            Instantiate(_blockPrefab, (Vector2)_spawnPosition, Quaternion.identity, _gameBoard.transform);
        }
    }
}
