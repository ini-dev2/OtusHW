using UnityEngine;
using Scripts.Common;
using Scripts.HealthSystem;

namespace Scripts.BulletsSystem
{
    public sealed class Bullet : MonoBehaviour, IBullet
    {
        private Vector2 _startVelocity;
        private PhysicsLayer _physicsLayer;
        private Vector3 _startPostion;
        private Color _color;
        private int _damage = 1;

        public void DealDamage(IHealth health)
        {
            health.TakeDamage(_damage);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent<IHealthProvider>(out var healthProvider))
            {
                Debug.Log("1");
                var health = healthProvider.Health;
                DealDamage(health);

                Destroy(gameObject);
            }
        }
    }
}