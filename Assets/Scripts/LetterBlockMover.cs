using UnityEngine;

namespace Etched
{
    public class LetterBlockMover : MonoBehaviour
    {
        Vector2 _targetPosition;

        [SerializeField] float _speed = 3;

        void Awake()
        {
            _targetPosition = transform.position;
        }
        void Update()
        {
            if ((Vector2)transform.position != _targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            }
        }

        public void SetTargetPosition(Vector2 position)
        {
            _targetPosition = position;
        }
    
    }
}