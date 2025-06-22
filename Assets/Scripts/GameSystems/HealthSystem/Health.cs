using System;
using UnityEngine.Events;

namespace Scripts.HealthSystem
{
    public sealed class Health : IHealth
    {
        public event UnityAction hpEmpty;

        private int _health;

        public Health(int health) => _health = health;

        public bool IsHitPointsExists() => _health > 0;

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage cant be <= 0");

            if (!IsHitPointsExists()) return;

            _health -= damage;

            if (_health <= 0) hpEmpty?.Invoke();
        }
    }
}