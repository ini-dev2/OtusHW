using UnityEngine;

namespace Scripts.MoveSystem
{
    public interface IMove
    {
        public void MoveByRigidbodyVelocity(Vector2 vector);
    }
}