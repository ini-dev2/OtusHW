using Scripts.HealthSystem;

namespace Scripts.BulletsSystem
{
    public interface IBullet
    {
        public void DealDamage(IHealth health);
    }
}