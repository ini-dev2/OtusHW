using UnityEngine.Events;

namespace Scripts.HealthSystem
{
    public interface IHealth
    {
        public event UnityAction hpEmpty;
        public bool IsHitPointsExists();
        public void TakeDamage(int damage);
    }
}