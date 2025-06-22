using UnityEngine;

namespace Scripts.MoveSystem
{
    public sealed class Move : IMove
    {
        private Rigidbody2D _rigidbody2D;
        private float _speed;

        public Move(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody2D = rigidbody2D;
            _speed = speed;
        }

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = _rigidbody2D.position + vector * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}